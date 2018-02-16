using ROSBridgeLib.Core;
using SimpleJSON;

/* 
 * @brief ROSBridgeLib
 * @author Michael Jenkin, Robert Codd-Downey, Andrew Speers and Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace std_msgs {
		public class UInt64MultiArrayMsg : ROSBridgeMessage {
			private MultiArrayLayoutMsg _layout;
            private ulong[] _data;

			public override string ROSMessageType
			{
				get{ return "std_msgs/UInt64MultiArray"; }
			}
			
			public UInt64MultiArrayMsg() { }
			
			public UInt64MultiArrayMsg(JSONNode msg) {
                _layout = new MultiArrayLayoutMsg(msg["layout"]);
                _data = new ulong[msg["data"].Count];
                for (int i = 0; i < _data.Length; i++) {
					_data[i] = ulong.Parse(msg["data"][i]);
                }
			}
			
			public UInt64MultiArrayMsg(MultiArrayLayoutMsg layout, ulong[] data) {
                _layout = layout;
				_data = data;
			}

			public ulong[] GetData() {
				return _data;
			}

            public MultiArrayLayoutMsg GetLayout() {
                return _layout;
            }

			public override void Deserialize(JSONNode msg)
			{
				_layout = new MultiArrayLayoutMsg(msg["layout"]);
				_data = new ulong[msg["data"].Count];
				for (int i = 0; i < _data.Length; i++) {
					_data[i] = ulong.Parse(msg["data"][i]);
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