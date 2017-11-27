package md50f72b6b716ee0e9120288a898c73126f;


public class NativeAdContentListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.formats.NativeContentAd.OnContentAdLoadedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onContentAdLoaded:(Lcom/google/android/gms/ads/formats/NativeContentAd;)V:GetOnContentAdLoaded_Lcom_google_android_gms_ads_formats_NativeContentAd_Handler:Android.Gms.Ads.Formats.NativeContentAd/IOnContentAdLoadedListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("NativeWebviewSample.NativeAdContentListener, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NativeAdContentListener.class, __md_methods);
	}


	public NativeAdContentListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NativeAdContentListener.class)
			mono.android.TypeManager.Activate ("NativeWebviewSample.NativeAdContentListener, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public NativeAdContentListener (md50f72b6b716ee0e9120288a898c73126f.NativeWbActivity p0, android.webkit.WebView p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == NativeAdContentListener.class)
			mono.android.TypeManager.Activate ("NativeWebviewSample.NativeAdContentListener, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "NativeWebviewSample.NativeWbActivity, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:Android.Webkit.WebView, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public void onContentAdLoaded (com.google.android.gms.ads.formats.NativeContentAd p0)
	{
		n_onContentAdLoaded (p0);
	}

	private native void n_onContentAdLoaded (com.google.android.gms.ads.formats.NativeContentAd p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
