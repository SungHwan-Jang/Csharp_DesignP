using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = Configuration.settings["user"];
            var password = Configuration.settings["password"];
            var address = Configuration.settings["address"];

            Console.WriteLine(String.Format("user :{0}, password :{1}, address :{2}", user, password, address as string));
        }
    }

    // 간단 사용 예
    public sealed class Configuration
    {
        // singleton 객체 선언
        public static Configuration settings = new Configuration();
        // Data 선언
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        private Configuration()
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            //ex -> json을 불러오든 뭐하든 한다. 예 이므로 그냥 add로 처리
            dict.Add("user", "redmk");
            dict.Add("password", "sunghwan");
            dict.Add("address", "anyang-si");
            dict.Add("phoneNumber", "010-9076-5675");
        }

        // 인덱서로 배열처럼 사용 가능케 한다.
        public object this[string key]
        {
            get
            {
                return dict[key];
            }
        }
    }


    // 싱글턴 개체 구현
    public sealed class Singleton
    {
        public Singleton singletonInstance = new Singleton();
        Dictionary<String, object> dict = new Dictionary<string, object>();

        private Singleton()
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            //ex -> json을 불러오든 뭐하든 한다. 예 이므로 그냥 add로 처리
            dict.Add("user", "redmk");
            dict.Add("password", "sunghwan");
            dict.Add("address", "anyang-si");
            dict.Add("phoneNumber", "010-9076-5675");
        }

        public object this[string key]
        {
            get
            {
                return dict[key];
            }
        }
    }
}
