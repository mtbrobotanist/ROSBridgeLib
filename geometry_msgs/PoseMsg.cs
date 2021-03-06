﻿using SimpleJSON;

/**
 * Define a geometry_msgs pose message. This has been hand-crafted from the corresponding
 * geometry_msgs message file.
 * 
 * @author Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace geometry_msgs {
		public class PoseMsg : Core.ROSBridgeMsg {
			public PointMsg _position;
			public QuaternionMsg _orientation;

			public override string ROSMessageType
			{
				get { return "geometry_msgs/Pose"; }
			}
			
			public PoseMsg() { }
			
			public PoseMsg(JSONNode msg) {
                _position = new PointMsg(msg["position"]);
                _orientation = new QuaternionMsg(msg["orientation"]);
            }

			public PoseMsg(PointMsg p, QuaternionMsg q) {
                _position = p;
                _orientation = q;
            }

			public PointMsg GetPosition() {
				return _position;
			}

			public QuaternionMsg GetOrientation() {
				return _orientation;
			}

			public override void Deserialize(JSONNode msg)
			{
				_position = new PointMsg(msg["position"]);
				_orientation = new QuaternionMsg(msg["orientation"]);
			}

			public override string ToString() {
				return ROSMessageType + " [position=" + _position.ToString() + ",  orientation=" + _orientation.ToString() + "]";
			}
			
			public override string ToYAMLString() {
				return "{\"position\": " + _position.ToYAMLString() + ", \"orientation\": " + _orientation.ToYAMLString() + "}";
			}
		}
	}
}
