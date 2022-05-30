using System;
using System.Collections.Generic;
using System.Linq;

namespace BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private T value;
        private BinarySearchTree<T> left;
        private BinarySearchTree<T> right;

        public BinarySearchTree(T value)
        {
            this.Value = value;
            this.left = null;
            this.right = null;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public IBinarySearchTree<T> Left
        {
            get
            {
                return this.left;
            }
        }

        public IBinarySearchTree<T> Right
        {
            get
            {
                return this.right;
            }
        }

        public int Height
        {
            get
            {
                int leftHeight;

                if (this.Left != null)
                {
                    leftHeight = this.Left.Height + 1;
                }
                else
                {
                    leftHeight = 0;
                }

                int rightHeight;

                if (this.Right != null)
                {
                    rightHeight = this.Right.Height + 1;
                }
                else
                {
                    rightHeight = 0;
                }



                return Math.Max(leftHeight, rightHeight);
            }
        }
        private void GetHeight(IBinarySearchTree<T> root,int height)
        {
            if(root.Left != null)
            {
                height++;
                GetHeight(root.Left,height);
            }
            if(root.Right != left)
            {
                height++;
                GetHeight(root.Right,height);
            }
        }

        public IList<T> GetInOrder()
        {
            var output = new List<T>();

            this.GetInOrder(this, output);

            return output;
        }

        private void GetInOrder(IBinarySearchTree<T> root, List<T> output)
        {
            if (root == null)
            {
                return;
            }

            this.GetInOrder(root.Left, output);

            output.Add(root.Value);

            this.GetInOrder(root.Right, output);
        }


        public IList<T> GetPostOrder()
        {
            var output = new List<T>();

            this.GetPostOrder(this, output);

            return output;
        }

        private void GetPostOrder(IBinarySearchTree<T> root, List<T> output)
        {
            if (root == null)
            {
                return;
            }

            this.GetPostOrder(root.Left, output);
            this.GetPostOrder(root.Right, output);

            output.Add(root.Value);
        }


        public IList<T> GetPreOrder()
        {
            var output = new List<T>();

            this.GetPreOrder(this, output);

            return output;
        }

        private void GetPreOrder(IBinarySearchTree<T> root, List<T> output)
        {
            if (root == null)
            {
                return;
            }

            output.Add(root.Value);

            this.GetPreOrder(root.Left, output);
            this.GetPreOrder(root.Right, output);
        }


        public IList<T> GetBFS()
        {
            var output = new List<T>();

            this.GetBFS(this, output);

            return output;
        }

        private void GetBFS(IBinarySearchTree<T> root, List<T> output)
        {
            if (root == null)
            {
                return;
            }

            var q = new Queue<IBinarySearchTree<T>>();

            q.Enqueue(root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                output.Add(node.Value);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public void Insert(T element)
        {
            BinarySearchTree<T> node = new BinarySearchTree<T>(element);


            if (value.CompareTo(element) >= 0)
            {
                if (left == null)
                {
                    left = node;
                }
                else
                {
                    left.Insert(element);
                }
            }
            else
            {
                if (right == null)
                {
                    right = node;
                }
                else
                {
                    right.Insert(element);
                }
            }
        }

        public bool Search(T element)
        {
            if (element.Equals(value))
            {
                return true;
            }
            else if (element.CompareTo(value) < 0)
            {
                if (left == null)
                {
                    return false;
                }
                else
                {
                    return left.Search(element);
                }
            }
            else
            {
                if (right == null)
                {
                    return false;
                }
                else
                {
                    return right.Search(element);
                }
            }
        }

        private IBinarySearchTree<T> GetMaxLeafNode(IBinarySearchTree<T> node)
        {
            if(this.right == null)
            {
                return node;
            }
            return this.right.GetMaxLeafNode(node.Right);
        }
        private IBinarySearchTree<T> GetMinLeafNode(IBinarySearchTree<T> node)
        {
            if(node.Left == node)
            {
                return node;
            }
            return this.GetMinLeafNode(node.Left);
        }
        public bool Remove(T element)
        {
            int comparison = element.CompareTo(this.value);

            if(comparison == 0) 
            {
                IBinarySearchTree<T> leafToRemove = null;
                if(this.left != null)
                {
                    leafToRemove = GetMaxLeafNode(this.left);
                }
                else if(this.right != null)
                {
                    leafToRemove = GetMinLeafNode(this.right);
                }
                var tmp = leafToRemove.Value;
                if (this.RemoveLeaf(leafToRemove))
                {
                    this.value = tmp;
                    return true;
                }
                return false;
            }

            if(comparison < 0 && this.left != null)
            {
                return this.left.Remove(element);
            }
            if(comparison >0 && this.right !=null)
            {
                return this.right.Remove(element);
            }

            return false;
        }

        private bool RemoveLeaf(IBinarySearchTree<T> leafToRemove)
        {
            if(this.left == leafToRemove)
            {
                this.left = null;
                return true;
            }

            if(leafToRemove == this.right)
            {
                this.right = null;
                return true;
            }

            if(this.left != null)
            {
                return this.left.RemoveLeaf(leafToRemove);
            }
            if(this.right != null)
            {
                return this.right.RemoveLeaf(leafToRemove);
            }
            return false;
        }
    }
}
