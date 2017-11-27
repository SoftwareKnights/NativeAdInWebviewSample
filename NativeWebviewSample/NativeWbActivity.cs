using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Java.Interop;
using Android.Gms.Ads;
using Android.Gms.Ads.Formats;
using System.Collections.Generic;
using Android.Util;
using Android.Graphics.Drawables;
using Android.Graphics;
using System.IO;
using Android.Content;
using Android.Views;
using System.Threading;
using System.Threading.Tasks;

namespace NativeWebviewSample {
    [Activity(Label = "NativeWebviewSample", MainLauncher = true)]
    public class NativeWbActivity : Activity {
        public Dictionary<int, NativeContentAdView> dic_nativeAds = new Dictionary<int, NativeContentAdView>();
        WebView webView;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            //Creates webview with interface and load ad-ready HTML
            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;
            webView.AddJavascriptInterface(new NativeWebviewJSInterface(this), "app_interface");
            webView.LoadUrl("file:///android_asset/Webview.html");


            //Load NativeAd and associate to listener that comunicates with HTML
            AdLoader.Builder adBuilder = new AdLoader.Builder(ApplicationContext, "ca-app-pub-3940256099942544/2247696110"); //SAMPLE AD UNIT ID 
            adBuilder.ForContentAd(new NativeAdContentListener(this, webView));
            adBuilder.Build().LoadAd(new AdRequest.Builder().AddTestDevice(AdRequest.DeviceIdEmulator).Build());
        }


        public void PopulateContentAdView(NativeContentAd ad, NativeContentAdView adView) {
            adView.HeadlineView = adView.FindViewById(Resource.Id.nativead_headline);
            adView.ImageView = adView.FindViewById(Resource.Id.nativead_image);
            adView.BodyView = adView.FindViewById(Resource.Id.nativead_body);
            adView.CallToActionView = adView.FindViewById(Resource.Id.nativead_callToAction);
            adView.LogoView = adView.FindViewById(Resource.Id.nativead_logo);
            adView.AdvertiserView = adView.FindViewById(Resource.Id.nativead_advertiser);

            // Some assets are guaranteed to be in every NativeContentAd.
            ((TextView) adView.HeadlineView).Text = ad.Headline;
            ((TextView) adView.BodyView).Text = ad.Body;
            ((TextView) adView.CallToActionView).Text = ad.CallToAction;
            ((TextView) adView.AdvertiserView).Text = ad.Advertiser;

            IList<NativeAd.Image> images = ad.Images;

            if (images.Count > 0) {
                ((ImageView) adView.ImageView).SetImageDrawable(images[0].Drawable);
            }

            // Some aren't guaranteed, however, and should be checked.
            NativeAd.Image logoImage = ad.Logo;

            if (logoImage == null) {
                adView.LogoView.Visibility = ViewStates.Invisible;
            } else {
                ((ImageView) adView.LogoView).SetImageDrawable(logoImage.Drawable);
                 adView.LogoView.Visibility = ViewStates.Visible;
            }

            // Assign native ad object to the native view.
            adView.SetNativeAd(ad);

        }

    }


    //Webview Javascript Interface to call native code when click on ad
    class NativeWebviewJSInterface : Java.Lang.Object {
        NativeWbActivity activity;

        public NativeWebviewJSInterface(NativeWbActivity activity) : base() {
            this.activity = activity;
        }

		[Export] [JavascriptInterface]
		public void ad_clicked(int ad_id, string sender) {
            activity.RunOnUiThread(() => {
                switch (sender) {
                    case "headline": activity.dic_nativeAds[ad_id].HeadlineView.PerformClick(); break;
                    case "image": activity.dic_nativeAds[ad_id].ImageView.PerformClick(); break;  
                    case "body": activity.dic_nativeAds[ad_id].BodyView.PerformClick(); break;
                    case "callToAction": activity.dic_nativeAds[ad_id].CallToActionView.PerformClick(); break;
                    case "advertiser": activity.dic_nativeAds[ad_id].AdvertiserView.PerformClick(); break;
                    //case "adChoices":  activity.dic_nativeAds[ad_id].AdChoicesView.PerformClick(); break; That dosn't work bcuz that PerformClick opens ad too instead Adchoices info
                    default: break;
                }
            });
		}
    }


    //Listener of native ad
    class NativeAdContentListener : Java.Lang.Object, NativeContentAd.IOnContentAdLoadedListener {
        NativeWbActivity activity;
        WebView webView;

        public NativeAdContentListener(NativeWbActivity activity, WebView webView) {
            this.activity = activity;
            this.webView = webView;
        }

        public void OnContentAdLoaded(NativeContentAd ad) {
            //Inflate and store it in a public dicctionary
            int ad_id = activity.dic_nativeAds.Count;
            
            LayoutInflater inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            NativeContentAdView ad_view = (NativeContentAdView) inflater.Inflate(Resource.Layout.NativeAdTemplate, null);
            activity.dic_nativeAds.Add(ad_id, ad_view);

            ad_view.AdChoicesView = new AdChoicesView(activity);
            activity.PopulateContentAdView(ad, ad_view);
            LinearLayout layout = activity.FindViewById<LinearLayout>(Resource.Id.ad_fake_placeholder);
            layout.AddView(ad_view);


            //Prepare Image to temp file to load it from webview
            string ad_imageFile = "";
            IList<NativeAd.Image> ad_images = ad.Images;
            if (ad_images.Count > 0) {
                Java.IO.File tempFile = Java.IO.File.CreateTempFile("adimg", ".jpg", activity.ApplicationContext.CacheDir);
                Bitmap bitmap = ((BitmapDrawable) ad_images[0].Drawable).Bitmap;
                MemoryStream stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                File.WriteAllBytes(tempFile.AbsolutePath, stream.ToArray());
                ad_imageFile = tempFile.AbsolutePath; 
            }


            //Pass ad information to webview
            string script = "ad_show("
                + ad_id + ", "
                + "'" + ad.Headline.Replace("'", "\\'") + "', "
                + "'" + ad_imageFile.Replace("'", "\\'") + "', "
                + "'" + ad.Body.Replace("'", "\\'") + "', "
                + "'" + ad.CallToAction.Replace("'", "\\'") + "', "
                + "'" + ad.Advertiser.Replace("'", "\\'") + "'"
            + ");";

            webView.EvaluateJavascript(script, null);
        }
    }


}

