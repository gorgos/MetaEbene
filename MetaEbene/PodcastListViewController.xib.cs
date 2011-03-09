
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MetaEbene
{
	public partial class PodcastListViewController : UIViewController
	{		
		//List<Podcast> podcastList;

		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public PodcastListViewController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public PodcastListViewController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public PodcastListViewController (int row) : base("PodcastListViewController", null)
		{
			Initialize (row);
		}

		void Initialize ()
		{
		}

		void Initialize (int row)
		{
			String url = "";
			
			if (row == 0)
				url = "0";
			if (row == 1)
				url = "1";
			if (row == 2)
				url = "2";
			
			Console.WriteLine ("Url = {0}", url);
		}		
		#endregion
	}
}

