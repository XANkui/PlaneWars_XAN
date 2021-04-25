/****************************************************
文件：LifeCycleMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/22 10:50:42
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LifeCycleMgr : MonoSingleton<LifeCycleMgr>,IInit
	{

        void IInit.Init()
        {
            LifeCycleAddConfig config = new LifeCycleAddConfig();
            config.Init();

            InitObject(config);

            LifeCycleConfig.LifecycleFuncs[LifeName.INIT]();
        }

        public void Add(LifeName name, object o) {
            LifeCycleConfig.Lifecycles[name].Add(o);
        }

        public void Remove(LifeName name, object o)
        {
            LifeCycleConfig.Lifecycles[name].Remove(o);
        }

        public void RemoveAll(object o)
        {
            foreach (var lifeCycle in LifeCycleConfig.Lifecycles)
            {
                lifeCycle.Value.Remove(o);
            }
        }

        private void Update()
        {
            LifeCycleConfig.LifecycleFuncs[LifeName.UPDATE]();
        }


        private void InitObject(LifeCycleAddConfig config) {
            foreach (object o in config._objects)
            {
                foreach (var lifeCycle in LifeCycleConfig.Lifecycles)
                {
                    if (lifeCycle.Value.Add(o)) {
                        break;
                    }
                }
            }
        }

    }

    public interface ILifeCycle {
        bool Add(object o);
        bool Remove(object o);
        void Execute<T>(Action<T> execute);
    }

    public class LifeCycle<T>: ILifeCycle
    {
        private HashSet<object> _objects = new HashSet<object>();
        private HashSet<object> _nullObjects = new HashSet<object>();

        public bool Add(object o) {
            if (o is T)
            {
                _objects.Add(o);
                return true;
            }

            return false;
        }

        public void Execute<T1>(Action<T1> execute)
        {
            foreach (var o in _objects)
            {
                if (o==null)
                {
                    _nullObjects.Add(o);
                }
                execute((T1)o);
            }

            foreach (object o in _nullObjects)
            {
                _objects.Remove(o);
            }

            _nullObjects.Clear();
        }

        public bool Remove(object o)
        {
            if (o is T)
            {
                _objects.Remove(o);
                return true;
            }

            return false;
        }
    }
}
