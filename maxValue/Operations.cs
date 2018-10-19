using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxValue
{
    public class Operations
    {
        #region Private fields
        private Node _rootNode;
        private string[] _lines;
        #endregion

        #region Public methods
        public List<int> FindThebiggestPath(int Level, string[] Lines)
        {
            try
            {
                _lines = Lines;
                _rootNode = InitializeTree(_lines[Level]);
                _rootNode.LeftChile = createLeftChild(ref _rootNode, Level + 1, 0);
                _rootNode.RightChile = createLeftChild(ref _rootNode, Level + 1, 1);

                Node MaxNode = travers(_rootNode);
                List<int> result = new List<int>();
                while (MaxNode != null)
                {
                    result.Insert(0, MaxNode.Value);
                    MaxNode = MaxNode.Parent;
                }
                return result;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// To determine if a number is odd or even 
        /// </summary>
        /// <param name="StringValue">Value from the file</param>
        /// <returns>Enum that shows being odd or even</returns>
        #endregion

        #region Private methods
        private NumberType TypeDeterminer(string StringValue)
        {
            try
            {
                int integerValue;
                bool isInteger = int.TryParse(StringValue, out integerValue);
                if (isInteger)
                {
                    if (integerValue % 2 == 0)
                        return NumberType.Even;
                    else
                        return NumberType.Odd;
                }
                else
                {
                    throw new Exception("The file structure is not correct!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Initialze the root of Binary tree with no parents and null children
        /// </summary>
        /// <param name="value">The value in the firt line</param>
        /// <returns>Root of Binary tree</returns>
        private Node InitializeTree(string value)
        {
            try
            {
                return new Node()
                {
                    Parent = null,
                    Sum = int.Parse(value),
                    Type = TypeDeterminer(value),
                    Value = int.Parse(value),
                    LeftChile = null,
                    RightChile = null,
                };
            }
            catch (Exception)
            {
                throw new Exception("Can not initialize the tree!");
            }
        }
        /// <summary>
        /// Add the left and right children to a node inside of the tree
        /// </summary>
        /// <param name="currentNode">The Parent node that we would like to add children to</param>
        /// <param name="level">The depth of the node </param>
        /// <param name="place">The index of the Value that should be added</param>
        /// <returns>Recently adeed node</returns>
        private Node createLeftChild(ref Node currentNode, int level, int place)
        {
            try
            {
                string value = string.Empty;
                if (_lines.Length > level)
                    value = _lines[level].Split(' ')[place];
                else
                    return null;

                Node ChildNode = new Node()
                {
                    Parent = currentNode,
                    Sum = int.Parse(value) + currentNode.Sum,
                    Type = TypeDeterminer(value),
                    Value = int.Parse(value)

                };
                if (currentNode.Type == NumberType.Even && TypeDeterminer(value) == NumberType.Odd || currentNode.Type == NumberType.Odd && TypeDeterminer(value) == NumberType.Even)
                {
                    ChildNode.LeftChile = createLeftChild(ref ChildNode, level + 1, place);
                    ChildNode.RightChile = createLeftChild(ref ChildNode, level + 1, place + 1);

                    //by commenting this line you can find the maximum value ever possible 
                    if (level != _lines.Length - 1)
                        ChildNode.Sum = 0;
                }
                else
                    return null;
                return ChildNode;
            }
            catch (Exception e)
            {
                throw new Exception("Error during creating the data structure",e);
            }

        }
        /// <summary>
        /// Find the maximum value in to binary tree
        /// </summary>
        /// <param name="root"> the root of the tree</param>
        /// <returns>Node with te maximum value </returns>
        private Node travers(Node root)
        {
            try
            {
                Node maxNode;
                Node lmaxNode;
                Node rmaxNode;
                if (root == null)
                    return new Node() { Sum = 0 };
                lmaxNode = travers(root.LeftChile);
                rmaxNode = travers(root.RightChile);
                if (lmaxNode.Sum >= rmaxNode.Sum)
                    maxNode = lmaxNode;
                else
                    maxNode = rmaxNode;
                if (maxNode.Sum >= root.Sum)
                    return maxNode;
                else
                    return root;
            }
            catch (Exception)
            {
                throw new Exception("Error during finding the max value");
            }

        }
        #endregion
    }
}
