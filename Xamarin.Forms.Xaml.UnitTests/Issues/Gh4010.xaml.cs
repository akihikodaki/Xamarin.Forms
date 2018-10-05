using NUnit.Framework;

namespace Xamarin.Forms.Xaml.UnitTests
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Gh4010 : Element
	{
		public Xamarin.Forms.DataTemplate Template { get; set; }

		public Gh4010()
		{
			InitializeComponent();
		}

		[TestFixture]
		public static class Tests
		{
			[TestCase]
			public static void PreserveName()
			{
				var i = new Gh4010();
				var templated = (Gh4010)i.Template.CreateContent();
				Assert.IsInstanceOf<Xamarin.Forms.DataTemplate>(templated.FindByName("template"));
			}
		}
    }
}
