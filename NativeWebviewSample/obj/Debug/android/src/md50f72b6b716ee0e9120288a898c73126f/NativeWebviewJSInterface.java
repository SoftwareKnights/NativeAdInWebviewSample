package md50f72b6b716ee0e9120288a898c73126f;


public class NativeWebviewJSInterface
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_ad_clicked:(ILjava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("NativeWebviewSample.NativeWebviewJSInterface, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NativeWebviewJSInterface.class, __md_methods);
	}


	public NativeWebviewJSInterface () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NativeWebviewJSInterface.class)
			mono.android.TypeManager.Activate ("NativeWebviewSample.NativeWebviewJSInterface, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public NativeWebviewJSInterface (md50f72b6b716ee0e9120288a898c73126f.NativeWbActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == NativeWebviewJSInterface.class)
			mono.android.TypeManager.Activate ("NativeWebviewSample.NativeWebviewJSInterface, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "NativeWebviewSample.NativeWbActivity, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	@android.webkit.JavascriptInterface

	public void ad_clicked (int p0, java.lang.String p1)
	{
		n_ad_clicked (p0, p1);
	}

	private native void n_ad_clicked (int p0, java.lang.String p1);

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
