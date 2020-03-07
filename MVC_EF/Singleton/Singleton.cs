using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.Singleton {
    public sealed partial class MySingleton {
        private static readonly MySingleton instance = new MySingleton();

        private MySingleton() { }

        public static MySingleton Instance {
            get {
                return instance;
            }
        }

        // automapper instance
        private static IMapper mapper;

        public static void AssignMapper(IMapper m) {
            mapper = m;
        }

        public static IMapper GetAutoMapperInstance() {
            return mapper;
        }

    }
}