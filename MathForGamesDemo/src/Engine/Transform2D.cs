using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class Transform2D
    {
        // transformation matrices
        private Matrix3 _localMatrix = Matrix3.Identinty;
        private Matrix3 _globalMatrix = Matrix3.Identinty;

        // transformation components
        private Matrix3 _localTranslation = Matrix3.Identinty;
        private Matrix3 _localRotation = Matrix3.Identinty;
        private Matrix3 _localScale = Matrix3.Identinty;

        // owner of the transform
        private Actor _owner;
        private Transform2D _parent;
        private Transform2D[] _children;


        // store local rotation

        private float _localRotationAngle;


        // Getting and Setting the local rotation Matrix
        public Matrix3 LocalRotation
        {
            get { return _localRotation; }
            set
            {
                // Set _localRotation
                _localRotation = value;
                // Set _localRotationAngle             
                _localRotationAngle = -(float)Math.Atan2(_localRotation.m01, _localRotation.m00);
                UpdateTransforms();
            }
        }
        //  getting and setting the local position as a Vector2
        public Vector2 LocalPosition
        {
            get { return new Vector2(_localTranslation.m02, _localTranslation.m12); }
            set
            {
                // update translation components of the translation matrix
                _localTranslation.m02 = value.x;
                _localTranslation.m12 = value.y;
                UpdateTransforms();
            }
        }
        //  getting the global position as a Vector2
        public Vector2 GlobalPositon
        {
            // global position from the global matrix
            get { return new Vector2(_globalMatrix.m02, _globalMatrix.m12); }
        }

        //  getting and setting the local scale as a Vector2
        public Vector2 LocalScale
        {
            get { return new Vector2(_localMatrix.m00, _localMatrix.m11); }
            set
            {
                // update the scale componests of the local scale matrix 
                _localScale.m00 = value.x;
                _localScale.m11 = value.y;
                UpdateTransforms();
            }
        }
        //  getting the global scale as a Vector2
        public Vector2 GlobalScale
        {
            get
            {
                // Calculate global scale based on the magnitudes of the axes from the global matrix
                Vector2 xAxis = new Vector2(_globalMatrix.m00, _globalMatrix.m10);
                Vector2 yAxis = new Vector2(_globalMatrix.m01, _globalMatrix.m11);

                return new Vector2(xAxis.Magnitude, yAxis.Magnitude);

            }

        }

        // getting the owner of the transform
        public Actor Owner
        {
            get { return _owner; } // returning the actor that owns the transform
        }

        // getting the forward direction vector
        public Vector2 Forward
        {
            // Forward direction based on global matrix

            get { return new Vector2(_globalMatrix.m00, _globalMatrix.m10).Normalized;  }
            
        }

        // getting the right direction vector
        public Vector2 Right
        {
            // right direction based on the global matrix
            get { return new Vector2(_globalMatrix.m01, _globalMatrix.m11).Normalized; }
        }

        // getting the local rotation angle in the radians
        public float LocalRotationAngle
        {
            get { return _localRotationAngle; }
        }

        // getting the global rotation angle in radians
        public float GlobalRotationAngle
        {
            // calculate the global rotation angle
            get { return (float)Math.Atan2(_globalMatrix.m01, _globalMatrix.m00); }
        }

        public Transform2D Parent { get => _parent; }

        public Transform2D[] Children { get => _children; }
        public Transform2D(Actor owner)
        {
            _owner = owner;
            _children = new Transform2D[0];
        }

        public void Translate(Vector2 direction)
        {
            LocalPosition += direction;
        }

        // function overload
        public void Translate(float x, float y)
        {
            LocalPosition += new Vector2(x, y);
        }
        public void Rotate(float radians)
        {
            LocalRotation = Matrix3.CreateRotation(_localRotationAngle + radians);
        }


        public void AddChild(Transform2D child)
        {
            /*
             * array tempArray set to new array[old.length + 1]
             * 
             * for each child in old array
             * copy child to new array
             * 
             *  tempArray[old.length set to new child
             *  
             *  set child parent to this instance
             *  
             *  set old array to new array
             */


            // Do not add the child if it is this transform's parent
           if (child == _parent)
            {
                return;
            }

            Transform2D[] temp = new Transform2D[_children.Length + 1];
            
            for (int i = 0; i < _children.Length; i++)
            {
                temp[i] = _children[i];

            }
            temp[_children.Length] = child;

            child._parent = this;

            _children = temp;



        }


        public bool RemoveChild(Transform2D child)
        {

            bool childRemoved = false;


            // If no children 
            // return false

            if (_children.Length <= 0)
            {
                return false;
            }

            Transform2D[] temp = new Transform2D[_children.Length - 1];

            // If only one child and that child is the correct one
            if (_children.Length == 1 && _children[0] == child)
            {
                childRemoved = true;

            }

            int j = 0;
            for (int i = 0; j < _children.Length - 1; i++)
            {
                if (_children[i] != child)

                {
                    temp[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }

            }


            if (childRemoved)
            {

                _children = temp;
                child._parent = null;
            }
            return childRemoved;

        }

        public void UpdateTransforms()
        {
            _localMatrix = _localTranslation * _localRotation * _localScale;

            // If parent is not null
            if (_parent != null)
            {
                // Global transfor - parent global transfor * local transform
                _globalMatrix = _parent._globalMatrix * _localMatrix;
            }

            // else
            else
            {
                // global transform = local transform
                _globalMatrix = _localMatrix;

            }


            // Update children
            foreach (Transform2D child in _children)
            {
                child.UpdateTransforms();
            }

        }

    }



}

