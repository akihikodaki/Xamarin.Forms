using NUnit.Framework;
using Xamarin.Forms.Core.UnitTests;

namespace Xamarin.Forms.Xaml.UnitTests
{
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class Gh5100Base : ContentPage
	{
		public Gh5100Base() => InitializeComponent();
	}

	[TestFixture]
	public class Gh5100 : Gh5100Base
	{
		void M(object sender, System.EventArgs args)
		{
		}

		[SetUp]
		public static void Setup()
		{
			Device.PlatformServices = new MockPlatformServices();
		}

		[TearDown]
		public static void TearDown()
		{
			Device.PlatformServices = null;
		}

		[TestCase(false)]
		[TestCase(true)]
		public static void Test(bool useCompiledXaml)
		{
			Assert.Throws<XamlParseException>(useCompiledXaml ?
				(TestDelegate)(() => MockCompiler.Compile(typeof(Gh5100Base))) :
				() => new Gh5100());
		}
	}
}
