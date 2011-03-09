using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MetaEbene
{
	[MonoTouch.Foundation.Register("PodcastsViewController")]
	public partial class PodcastsViewController : UITableViewController
	{
		static NSString kCellIdentifier = new NSString ("MyIdentifier");

		string[] podcastTitles = { "CRE", "MobileMacs", "NSFW" };

		List<PodcastListViewController> ListViewController;

		//
		// Constructor invoked from the NIB loader
		//
		public PodcastsViewController (IntPtr p) : base(p)
		{
			this.ListViewController = new List<PodcastListViewController> ();
			for (int i = 0; i < this.podcastTitles.Length; i++) {
				this.ListViewController.Add (null);
			}
		}


		//
		// The source for our TableView
		//
		class TableSource : UITableViewSource
		{
			PodcastsViewController mtvc;

			public TableSource (PodcastsViewController mtvc)
			{
				this.mtvc = mtvc;
			}

			public override int RowsInSection (UITableView tableView, int section)
			{
				return this.mtvc.podcastTitles.Length;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (kCellIdentifier);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, kCellIdentifier);
				}
				
				// Customize the cell here...
				
				cell.TextLabel.Text = this.mtvc.podcastTitles[indexPath.Row];
				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				Console.WriteLine ("MetaEbene: Row selected {0}", indexPath.Row);
				if (this.mtvc.ListViewController.ElementAt (indexPath.Row) == null){					
					this.mtvc.ListViewController.RemoveAt(indexPath.Row);
					this.mtvc.ListViewController.Insert(indexPath.Row, new PodcastListViewController(indexPath.Row));
				}
								
				this.mtvc.NavigationController.PushViewController (this.mtvc.ListViewController.ElementAt (indexPath.Row), true);				
				
				// Console.WriteLine ("Link: {0}", mtvc.strings.ElementAt (indexPath.Row).Link);
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
						/*XDocument rss = XDocument.Load ("http://feeds.feedburner.com/mobile-macs-podcast");
			
			var query = from item in rss.Descendants ("item")
				select new Podcast { Headline = (string)item.Element ("title"), Link = (string)item.Element ("link") };
			
			strings = query.ToList ();*/
			TableView.Source = new TableSource (this);
		}
		
	}
}
