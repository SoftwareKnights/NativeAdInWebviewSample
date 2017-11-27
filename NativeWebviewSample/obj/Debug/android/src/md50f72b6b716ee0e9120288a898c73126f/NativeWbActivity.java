package md50f72b6b716ee0e9120288a898c73126f;


public class NativeWbActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("NativeWebviewSample.NativeWbActivity, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NativeWbActivity.class, __md_methods);
	}


	public NativeWbActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NativeWbActivity.class)
			mono.android.TypeManager.Activate ("NativeWebviewSample.NativeWbActivity, NativeWebviewSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
