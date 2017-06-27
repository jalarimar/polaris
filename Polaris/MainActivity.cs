using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Polaris
{
    [Activity(Label = "Polaris", MainLauncher = true, Icon = "@drawable/snowflake")]
    public class MainActivity : Activity
    {
        int count = 1;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://polarisapp.azurewebsites.net");

        public class TodoItem
        {
            public string Id { get; set; }
            public string Text { get; set; }
        }

        public async Task<int> addAwesomeItem() {
            TodoItem item = new TodoItem { Text = "Awesome item" };
            await MobileService.GetTable<TodoItem>().InsertAsync(item);

            int i = 0;
            return i;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // SetContentView (Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);
            };

            

//            A pot contains 75 white beans and 150 black ones. Next to the pot is a large pile of black beans.
//A somewhat demented cook removes the beans from the pot, one at a time, according to the following strange rule: He removes two beans from the pot at random.If at least one of the beans is black, he places it on the bean-pile and drops the other bean, no matter what color, back in the pot. If both beans are white, on the other hand, he discards both of them and removes one black bean from the pile and drops it in the pot.
//At each turn of this procedure, the pot has one less bean in it.Eventually, just one bean is left in the pot. What color is it?
        }
    }
}

