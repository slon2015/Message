using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packager
{
    public static class HaffmanCoder
    {
        public static string Code(string input)
        {
            string ret = "";
            return ret;
        } 
        public class HTree
        {
            List<IHTNode> nodes;
            string EndCode;
            public HTree()
            {
                nodes.Add(new EscapeNode());
                EndCode = "0";
            }
            interface IHTNode
            {
                string code { get; set; }
                HTNode _Parent { get; set; }
                int _Weight { get; set; }
            }
            class EscapeNode : IHTNode
            {
                public string code { get; set; }
                public HTNode _Parent { get; set; }
                public int _Weight { get; set; }
                public EscapeNode()
                {
                    _Weight = 0;
                    code = "0";
                }
            }
            class HTLeaf : IHTNode
            {
                public string code { get; set; }
                public HTNode _Parent { get; set; }
                public int _Weight { get; set; }
                public HTLeaf(HTNode parent)
                {
                    _Parent = parent;
                    code = _Parent.code;
                    if (_Parent._Left == this)
                        code += "1";
                    else
                        code += "0";
                }
            }
            class HTNode:IHTNode
            {
                public IHTNode _Right;
                public IHTNode _Left;
                public HTNode _Parent { get; set; }
                public int _Weight { get; set; }
                public HTNode(int count,IHTNode right=null,IHTNode left=null,HTNode parent = null)
                {
                    _Weight = 0;
                    _Right = right;
                    _Left = left;
                    _Parent = parent;
                }
                public string code { get; set; }
            }
        }
    }
}
