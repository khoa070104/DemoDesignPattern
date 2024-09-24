namespace BuilderDesignPattern
{
	//Builder Interface: chỉ định các phương phương pháp để tạo các phần khác nhau Product object 
	public interface IBuilder
	{
		void ThemChanChoMayBay();

		void ThemTenLuaChoDitMayBay();

		void ThemKhachSanChoMayBay();
	}

	public class ConcreteBuilder : IBuilder
	{
		private Product _product = new Product();

		public ConcreteBuilder()
		{
			this.Reset();
		}

		public void Reset()
		{
			this._product = new Product();
		}


		public void ThemChanChoMayBay()
		{
			this._product.Add("May Bay Da Co Chan");
		}

		public void ThemTenLuaChoDitMayBay()
		{
			this._product.Add("May Bay da duoc them ten lua vao DIT");
		}

		public void ThemKhachSanChoMayBay()
		{
			this._product.Add("May bay da co Hotel Service");
		}

		public Product GetProduct()
		{
			Product result = this._product;

			this.Reset();

			return result;
		}
	}

	public class Product
	{
		private List<object> _parts = new List<object>();

		public void Add(string part)
		{
			this._parts.Add(part);
		}

		public string ListParts()
		{
			string str = string.Empty;

			for (int i = 0; i < this._parts.Count; i++)
			{
				str += this._parts[i] + " - ";
			}

			str = str.Remove(str.Length - 2);

			return "MAY BAY NAY : " + str + "\n";
		}
	}


	public class Director
	{
		private IBuilder _builder;

		public IBuilder Builder
		{
			set { _builder = value; }
		}

		public void GoiBuildTietKiem()
		{
			this._builder.ThemChanChoMayBay();
		}

		public void GoiBuildVippro()
		{
			this._builder.ThemChanChoMayBay();
			this._builder.ThemTenLuaChoDitMayBay();
			this._builder.ThemKhachSanChoMayBay();
		}
	}

	class Program
	{
		//Main: Client code tạo một builder object, chuyển cho Director,và bắt đầu chạy, kết quả sẽ được truy xuất từ builder object
		static void Main(string[] args)
		{
			var director = new Director();
			var builder = new ConcreteBuilder();
			director.Builder = builder;

			Console.WriteLine("Nha Ngheo Nen Build Goi Co Ban:");
			director.GoiBuildTietKiem();
			Console.WriteLine(builder.GetProduct().ListParts());

			Console.WriteLine("Nha Giau nen build Goi Vippro Max Iphone 100 xs pro plus:");
			director.GoiBuildVippro();
			Console.WriteLine(builder.GetProduct().ListParts());

			Console.WriteLine("Goi custom cho dan chuyen do:");
			builder.ThemChanChoMayBay();
			builder.ThemKhachSanChoMayBay();
			Console.Write(builder.GetProduct().ListParts());
		}
	}

}
