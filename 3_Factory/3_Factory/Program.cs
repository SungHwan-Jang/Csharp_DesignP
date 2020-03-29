using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Static Factory Method Pattern
            // use static method
            ILogger_static_factory logger_static_factory = LoggerFactory_static_factory.Create(LoggerType.DB);

            #endregion

            #region Simple Factory Pattern
            // no using static method
            var factory_simple = new LoggerFactory_simple_factory();
            var dbLogger_simple = factory_simple.CreateDbLogger();

            #endregion

            #region Factory Method Pattern

            LogFactory logger = new XmlLogFactory();
            logger.Log("Log something");

            LogFactory logger_s = LogFactory.GetLogger();
            logger_s.Log("Log somethinf");

            #endregion


            #region Abstract Factory Patthern

            AbstractFactory factory = new ConcreteFactory1();
            ProductA prodA = factory.CreateProductA();
            ProductB prodB = factory.CreateProductB();

            #endregion

        }
    }

    #region ex Singleton configuration
    public class Configuration
    {
        public static Configuration Settings = new Configuration();
        private string _data = null;

        private Configuration()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            _data = "test";
        }
        public object this[string key]
        {
            get
            {
                return _data;
            }
        }
    }
    #endregion

    #region ex enum
    public enum LoggerType
    {
        DB,
        XML,
        JSON
    }
    #endregion

    #region Static Factory Method Pattern

    /* Static Factory Method pattern */



    interface ILogger_static_factory { }
    class DbLogger_static_factory : ILogger_static_factory { }
    class XmlLogger_static_factory : ILogger_static_factory { }
    class JsonLogger_static_factory : ILogger_static_factory { }

    class LoggerFactory_static_factory
    {
        // Static Factory Method
        // loggertype는 enum으로 하는 것이 일반적이다.

        public static ILogger_static_factory Create(LoggerType loggerType)
        {
            ILogger_static_factory logger = null;
            
            switch (loggerType)
            {
                case LoggerType.DB:
                    logger = new DbLogger_static_factory();
                    break;
                case LoggerType.XML:
                    logger = new XmlLogger_static_factory();
                    break;
                case LoggerType.JSON:
                    logger = new JsonLogger_static_factory();
                    break;
                default:
                    throw new InvalidOperationException();

            }

            return logger;
        }
    }

    /* Static Factory Method pattern */

    #endregion

    #region Simple Factory Pattern

    class DbLogger_simple_factory { }

    class LoggerFactory_simple_factory
    {
        public DbLogger_simple_factory CreateDbLogger()
        {
            string connStr = Configuration.Settings["DBConn"].ToString();
            var db = new DbLogger_simple_factory();
            //db.TimeOut = 60;
            //db.Error += () => { /**/}

            return db;
        }
    }

    #endregion

    #region Factory Method Pattern

    interface ILog
    {
        void Write(string s);
    }

    class XmlLog : ILog
    {
        private string xmlFile;

        public XmlLog(string xmlFile)
        {
            this.xmlFile = xmlFile;
        }

        public void Write(string s)
        {
            //..
        }
    }

    class DbLog : ILog
    {
        private string connString;
        public DbLog(string connString)
        {
            this.connString = connString;
        }

        public void Write(string s)
        {
            //..
        }
    }

    abstract class LogFactory
    {
        // factory method 패턴
        protected abstract ILog GetLog();

        public void Log(string message)
        {
            var logger = GetLog(); // 어떤 타입의 로그를 사용할지 아직 모름
            logger.Write($"{DateTime.Now}: {message}");
        }

        // 추가적으로 static factory method 사용할 경우
        public static LogFactory GetLogger()
        {
            string logType = Configuration.Settings["DB"].ToString(); //for test return always "test"

            switch (logType)
            {
                case "DB":
                    return new DbLogFactory();
                case "XML":
                    return new XmlLogFactory();
                default: //for test
                    return new DbLogFactory();
            }
        }
    }

    class DbLogFactory : LogFactory
    {
        protected override ILog GetLog()
        {
            string logfile = Configuration.Settings["XmlFile"].ToString();

            var xmlLog = new XmlLog(logfile);
            return xmlLog;
        }
    }

    class XmlLogFactory : LogFactory
    {
        protected override ILog GetLog()
        {
            string connString = Configuration.Settings["DBConn"].ToString();
            return new DbLog(connString);
        }
    }

    #endregion

    #region Abstract Factory Patthern

    //abstract Factory

    public class ProductA { }
    public class ConcreteProduct1A : ProductA { }
    public class ConcreteProduct2A : ProductA { }

    public class ProductB { }
    public class ConcreteProduct1B : ProductB { }
    public class ConcreteProduct2B : ProductB { }

    public abstract class AbstractFactory
    {
        public abstract ProductA CreateProductA();
        public abstract ProductB CreateProductB();
    }

    //Concrete Factory class
    public class ConcreteFactory1 : AbstractFactory
    {
        public override ProductA CreateProductA()
        {
            return new ConcreteProduct1A();
        }

        public override ProductB CreateProductB()
        {
            return new ConcreteProduct1B();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override ProductA CreateProductA()
        {
            return new ConcreteProduct2A();
        }

        public override ProductB CreateProductB()
        {
            return new ConcreteProduct2B();
        }
    }

    #endregion
}
