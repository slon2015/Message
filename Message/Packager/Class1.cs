using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packager
{
    public static class HaffmanCoder
    {
        public class CodeInfo
        {
            public string value;
            public string CompressedValue;
            public HTree Coder;
            public CodeInfo(string input)
            {
                Coder = new HTree();
                string bits = Coder.Code(input);
                value = bits;
                string CompressInput = "";
                while (bits.Length >= 16)
                {
                    CompressInput += (char)Convert.ToInt32(bits.Substring(0, 16), 2);
                    bits = bits.Substring(16);
                }
                if(bits.Length!=0)
                    CompressInput += (char)Convert.ToInt32(bits, 2);
                CompressedValue = CompressInput;
            }
        }
        public class DecodeInfo
        {
            public string value;
            public HTree Decoder;
            public DecodeInfo(string input)
            {
                Decoder = new HTree();
                string decompressedInput = "";
                for(int i = 0; i < input.Length; i++)
                {
                    string bits = Convert.ToString((int)input[i], 2);
                    while (bits.Length < 16 && i != input.Length - 1)
                        bits = "0" + bits;
                    //while (bits[0] != '1')
                    //    bits.Remove(0, 1);
                    decompressedInput += bits;
                }
                value = Decoder.Decode(decompressedInput);
            }
        }
        public static CodeInfo Code(string input)
        {
            return new CodeInfo(input);
        } 
        public static DecodeInfo Decode(string input)
        {
            return new DecodeInfo(input);
        }
        public class HTree
        {
            static List<IHTNode> nodes;
            string EndCode
            {
                get
                {
                    return (nodes.Find(n => n is EscapeNode) as EscapeNode).code;
                }
            }
            public HTree()
            {
                nodes = new List<IHTNode>();
                nodes.Add(new EscapeNode());
                
                
            }
            public string Code(string Input)
            {
                string ret = "";
                var enumerator = Input.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string code = "";
                    char c = enumerator.Current;
                    if (!Contain(c))
                    {
                        var ar = Convert.ToString(c, 2);
                        while (ar.Length < 12)
                            ar = "0" + ar;
                        code = EndCode + ar;
                        //for (int i = 0; i < ar.Length; i++)
                        //    code += ar[i];
                        Add(c);
                    }
                    else
                        code = Search(c).code;
                    ret += code;
                    Search(c).Increment();
                    UpdateNodes();
                }
                return ret;
            }
            public string Decode(string input)
            {
                string ret = "";
                string temp = input.Substring(0, 12);
                input = input.Substring(12);
                char sim = (char)Convert.ToInt32(temp, 2);
                ret += sim;
                Add(sim);
                Search(sim).Increment();
                UpdateNodes();

                while (input != "")
                {
                    IHTNode[] NodesAr = nodes.ToArray();
                    for(int i=0;i<NodesAr.Length;i++)
                    {
                        IHTNode node = NodesAr[i];
                        if(!(node is HTNode))
                        {
                            if(input.Length>=node.code.Length)
                                if (input.Substring(0, node.code.Length) == node.code)
                                {
                                    input = input.Substring(node.code.Length);
                                    if(node is HTLeaf)
                                    {
                                        sim = (node as HTLeaf).sim;
                                        ret += sim;
                                        Search(sim).Increment();
                                        
                                    }
                                    if(node is EscapeNode)
                                    {
                                        temp = input.Substring(0, 12);
                                        input = input.Substring(12);
                                        sim = (char)Convert.ToInt32(temp, 2);
                                        ret += sim;
                                        Add(sim);
                                        Search(sim).Increment();
                                        continue;
                                    }
                                    UpdateNodes();
                                }
                        }
                    }
                }
                return ret;
            }
            public string getCodeOf(char c)
            {
                if (Contain(c))
                    return (nodes.Find(l => l is HTLeaf&&(l as HTLeaf).sim == c)as HTLeaf).code;
                return null;
            }
            public bool Contain(char c)
            {
                HTLeaf leaf = (HTLeaf)nodes.Find(l => l is HTLeaf && (l as HTLeaf).sim == c);
                if (leaf != null)
                    return true;
                else
                    return false;
            }
            interface IHTNode
            {
                string code { get; }
                HTNode _Parent { get; set; }
                int _Weight { get; set; }
                
            }
            class EscapeNode : IHTNode
            {
                public string code
                {
                    get
                    {
                        string ret = "";
                        if (_Parent == null)
                            return ret;
                        HTNode active = _Parent;
                        IHTNode pursuing = this;
                        do
                        {
                            if (active._Left == pursuing)
                                ret = "1" + ret;
                            else
                                ret = "0" + ret;
                            pursuing = active;
                            active = active._Parent;
                        }
                        while (active != null);
                        return ret;
                    }
                }
                public HTNode _Parent { get; set; }
                public int _Weight { get; set; }
                public EscapeNode()
                {
                    _Weight = 0;
                    
                }
            }
            void UpdateNodes()
            {
                foreach (IHTNode node in nodes)
                    if(node is HTNode)
                    node._Weight = (node as HTNode)._Right._Weight + (node as HTNode)._Left._Weight;
            }
            class HTLeaf : IHTNode
            {
                public string code
                {
                    get
                    {
                        string ret = "";
                        HTNode active = _Parent;
                        IHTNode pursuing = this;
                        do
                        {
                            if (active._Left == pursuing)
                                ret = "1" + ret;
                            else
                                ret = "0" + ret;
                            pursuing = active;
                            active = active._Parent;
                        }
                        while (active != null);
                        return ret;
                    }
                }
                public HTNode _Parent { get; set; }
                public int _Weight { get; set; }
                public char sim;
                public HTLeaf(HTNode parent,char c)
                {
                    _Parent = parent;
                    //code = _Parent.code;
                    //if (_Parent._Left == this)
                    //    code = "1" + code;
                    //else
                    //    code = "0" + code;
                    sim = c;
                    _Weight = 0;
                    nodes.Add(this);
                }
                static void ExchangeLeaf(HTLeaf l1, IHTNode l2)
                {
                    object temp;
                    temp = l1._Parent;
                    l1._Parent = l2._Parent;
                    l2._Parent = (HTNode)temp;
                    temp = l1.code;
                    
                        
                    
                }
                public void Increment()
                {
                    
                    IHTNode active = this;
                    while (active != null)
                    {
                        active._Weight++;
                        active = active._Parent;
                    }
                    IHTNode target;
                    do
                    {
                        target = HTree.nodes.Find(l => (l as IHTNode).code.Length < code.Length && l._Weight < _Weight);
                        if (target != null)
                            ExchangeLeaf(this, target);
                    } while (target != null);
                }
            }
            class HTNode:IHTNode
            {
                public string code
                {
                    get
                    {
                        if (_Parent == null)
                            return "";
                        string ret = "";
                        HTNode active = _Parent;
                        IHTNode pursuing = this;
                        do
                        {
                            if (active._Left == pursuing)
                                ret = "1" + ret;
                            else
                                ret = "0" + ret;
                            pursuing = active;
                            active = active._Parent;
                        }
                        while (active != null);
                        return ret;
                    }
                }
                public IHTNode _Right;
                public IHTNode _Left;
                public HTNode _Parent { get; set; }
                public int _Weight { get; set; }
                public HTNode(IHTNode right=null,IHTNode left=null,HTNode parent = null)
                {
                    _Weight = 0;
                    _Right = right;
                    _Left = left;
                    _Parent = parent;
                    if (_Right != null)
                        _Right._Parent = this;
                    if (_Left != null)
                        _Left._Parent = this;
                    
                    //if (_Parent == null)
                    //    code = "";
                    //else
                    //{
                    //    if (_Parent._Left == this)
                    //        code = "1" + _Parent.code;
                    //    else
                    //        code = "0" + _Parent.code;
                    //}
                    nodes.Add(this);
                }
                //public string code { get; set; }
            }
            HTLeaf Search(char c)
            {
                foreach (IHTNode leaf in nodes)
                    if(leaf is HTLeaf)
                    if ((leaf as HTLeaf).sim == c)
                        return (HTLeaf)leaf;
                return null;
            }
            public void Add(char c)
            {
                EscapeNode esc = (EscapeNode)nodes.Find(node=>node is EscapeNode);
                HTNode oldEscParent = esc._Parent;
                HTNode newNode = new HTNode(null, esc, esc._Parent);
                if (oldEscParent != null)
                    oldEscParent._Left = newNode;
                HTLeaf newLeaf = new HTLeaf(newNode, c);
                newNode._Right = newLeaf;
                //esc._Parent._Left = newNode;
                //if (newNode._Parent != null)
                //    newNode.code = "1" + newNode._Parent.code;
                //else
                //    newNode.code = "1";
                //esc.code += "1";
                
                //UpdateNodes();
                
            }
        }
    }
}
