using System.Linq.Expressions;

namespace AbstractFactoryDesignPattern
{
	internal class Program
	{
		interface IButton {
			void CreateButton();
		}
		class WindowButton : IButton
		{
			public void CreateButton()
			{
                Console.WriteLine("Created Button for Window ");
			}
		}

		class MacButton : IButton
		{
			public void CreateButton()
			{
				Console.WriteLine("Created Button for Mac ");
			}
		}

		interface ICheckbox { 
			void CreateCheckbox();
		}

		class WindowCheckbox : ICheckbox
		{
			public void CreateCheckbox()
			{
				Console.WriteLine("Created Checkbox for Window ");
			}
		}

		class MacCheckbox : ICheckbox
		{
			public void CreateCheckbox()
			{
				Console.WriteLine("Created Checkbox for Mac ");
			}
		}

		interface IFactory
		{
			IButton Button();
			ICheckbox Checkbox();
		}

		class WindowFactory : IFactory
		{
			public IButton Button()
			{
				return new WindowButton() ;
			}

			public ICheckbox Checkbox()
			{
				return new WindowCheckbox();
			}
		}
		class MacFactory : IFactory
		{
			public IButton Button()
			{
				return new MacButton();
			}

			public ICheckbox Checkbox()
			{
				return new MacCheckbox();
			}
		}

		class Client
		{
			IButton button;
			ICheckbox checkbox;
			public Client(IFactory factory){
				button = factory.Button();
				checkbox = factory.Checkbox();
			}
			public void Result()
			{
				button.CreateButton();
				checkbox.CreateCheckbox();
			}

		}

		static void Main(string[] args)
		{
			IFactory f = new WindowFactory();
			Client c = new Client(f);
			c.Result();
		}
	}
}
