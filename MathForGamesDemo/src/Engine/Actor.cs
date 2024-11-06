using MathForGamesDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class Actor
    {

        private bool _started = false;
        private bool _enabled = true;

        private Component[] _components;

        public string Name { get; set; }

        public Transform2D Transform { get; protected set; }

        public bool Started { get => _started; }
        public bool Enabled
        {
            get => _enabled;
            set
            {
                // If enabled would not change, do nothing
                if (_enabled == value) return;

                _enabled = value;
                // If value is true, call OnEnabled

                if (_enabled)
                    OnEnable();

                // If value is false, call OnEnabled

                else OnDisable();
            }
        }

        public Collider Collider { get; set; }

        public Actor(string name = "Actor")
        {
            Name = name;
            Transform = new Transform2D(this);
            _components = new Component[0];
        }

        public static Actor Instantiate(
            Actor actor,
            Transform2D parent = null,
            Vector2 position = new Vector2(),
            float rotation = 0,
            string name = "Actor")
        {
            // Set actor transform values
            actor.Transform.LocalPosition = position;
            actor.Transform.Rotate(rotation);
            actor.Name = name;
            if (parent != null)
                parent.AddChild(actor.Transform);

            // Add actor to current scene
            Game.CurrentScene.AddActor(actor);

            return actor;
        }
        public static void Destroy(Actor actor)
        {
            // Remove all children
            foreach (Transform2D child in actor.Transform.Children)
            {
                actor.Transform.RemoveChild(child);
            }

            // Unchild from parent
            if (actor.Transform.Parent != null)
                actor.Transform.Parent.RemoveChild(actor.Transform);

            Game.CurrentScene.RemoveActor(actor);

        }
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }

        public virtual void Start()
        {
            _started = true;

        }

        public virtual void Update(double deltaTime) 
        {
            foreach (Component component in _components)
            {
                if (!component.Started)
                    component.Start();

                component.Update(deltaTime);
            }

        }




        public virtual void End() 
        {
            foreach (Component component in _components)
            {
                component.End();
            }
        
        }

        public virtual void OnCollision(Actor other) { }

        // Add component
        public T AddComponent<T>(T component) where T : Component
        {
            // Create temporary array one bigger than _components
            Component[] temp = new Component[_components.Length + 1];

            //Deep copy _components into temp
            for (int i = 0; i < _components.Length; i++)
            {
                temp[i] = _components[i];
            }

            // Set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = component;

            // Store temp in _components
            _components = temp;

            return null;
        }


        public T AddComponent<T>() where T : Component
        {

            T component = (T)new Component(this);
            return AddComponent(component);
        }




        // Remove component
        public bool RemoveComponent<T>(T component) where T : Component
        {
            // Edge case for empty component array
            if (_components.Length <= 0)
                return false;

            // Edge case for only one component
            if (_components.Length == 1 && _components[0] == component)
            {
                _components = new Component[0];
                return true;
            }

            // Create a temp array one smaller than _components
            Component[] temp = new Component[_components.Length - 1];
            bool componentRemoved = false;

            // Deep copy _components into temp minus the one component
            int j = 0;
            for (int i = 0; j < _components.Length - 1; i++)
            {
                if (_components[i] != component)
                {
                    temp[j] = _components[i];
                    j++;
                }
                else
                {
                    componentRemoved = true;
                }
            }
            // If a component was removed, assign temp over _components
            if (componentRemoved)
            {
                _components = temp;
            }

            return componentRemoved;
        }

        public bool RemoveComponent<T>() where T : Component
        {
            T component = GetComponent<T>();
            if (component != null)
                return RemoveComponent(component);
            return false;
        }
        // Get component
        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in _components)
            {
                if (component is T)
                    return (T)component;
            }
            return null;
        }
        // Get components
        public T[] GetComponents<T>() where T : Component
        {
            // Create a temp array of the same size as _components
            T[] temp = new T[_components.Length];

            // Copy all elements that are of type T into temp
            int count = 0;
            for (int i = 0; i < _components.Length; i++)
            {
                if (_components[i] is T)
                {
                    temp[count] = (T)_components[i];
                    count++;
                }
            }

            // Trim the array
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }

            return result;
        }




    }
}
