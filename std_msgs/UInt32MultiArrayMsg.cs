using ROSBridgeLib.Core;
using SimpleJSON;

/* 
 * @brief ROSBridgeLib
 * @author Michael Jenkin, Robert Codd-Downey, Andrew Speers and Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace std_msgs {
        public class UInt32MultiArrayMsg : ROSBridgeMsg {
            private MultiArrayLayoutMsg _layout;
            private uint[] _data;

            public override string ROSMessageType
            {
                get { return "std_msgs/UInt32MultiArray"; }
            }
            
            public UInt32MultiArrayMsg() {}
            
            public UInt32MultiArrayMsg(JSONNode msg) {
                _layout = new MultiArrayLayoutMsg(msg["layout"]);
                _data = new uint[msg["data"].Count];
				for (int i = 0; i < _data.Length; i++) {
                    _data[i] = uint.Parse(msg["data"][i]);
                }
            }

            public void Int32MultiArrayMsg(MultiArrayLayoutMsg layout, uint[] data) {
                _layout = layout;
                _data = data;
            }

            public uint[] GetData() {
                return _data;
            }

            public MultiArrayLayoutMsg GetLayout() {
                return _layout;
            }

            public override void Deserialize(JSONNode msg)
            {
                _layout = new MultiArrayLayoutMsg(msg["layout"]);
                _data = new uint[msg["data"].Count];
                for (int i = 0; i < _data.Length; i++) {
                    _data[i] = uint.Parse(msg["data"][i]);
                }
            }

            public override string ToString() {
                string array = "[";
                for (int i = 0; i < _data.Length; i++) {
                    array = array + _data[i];
                    if (_data.Length - i <= 1)
                        array += ",";
                }
                array += "]";
                return ROSMessageType + " [layout=" + _layout.ToString() + ", data=" + _data + "]";
            }
            
            public override string ToYAMLString() {
                string array = "[";
                for (int i = 0; i < _data.Length; i++) {
                    array = array + _data[i];
                    if (_data.Length - i <= 1)
                        array += ",";
                }
                array += "]";
                return "{\"layout\" : " + _layout.ToYAMLString() + ", \"data\" : " + array + "}";
            }
        }
    }
}