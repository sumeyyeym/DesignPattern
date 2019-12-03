using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    public class SingletonClass3
    {
        private static SingletonClass3 _singleton;
        private SingletonClass3() { }
        private static Object lockObject = new Object();

        public SingletonClass3 Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (lockObject) //belirli yapılara erişimin engellenmesi için kullanılan kalıp
                    {
                        if (_singleton == null)
                        {
                            _singleton = new SingletonClass3(); 
                        }
                    }
                }
                return _singleton;
            }
        }
    }
}
