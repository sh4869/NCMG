using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

public class HandPositionView : MonoBehaviour
{
    public GameObject ColorBodySourceManager;

    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private ColorBodySourceManager _BodyManager;

    public Camera ConvertCamera;

    private Kinect.CoordinateMapper _CoordinateMapper;

    private int _KinectWidth = 1920;
    private int _KinectHeight = 1080;
	
    private List<Kinect.JointType> handtypes = new List<Kinect.JointType>{Kinect.JointType.HandLeft,Kinect.JointType.HandRight};

    void Update()
    {
        if (ColorBodySourceManager == null)
        {
            return;
        }

        _BodyManager = ColorBodySourceManager.GetComponent<ColorBodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }

        Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }

        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
            }
        }

        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);

        // First delete untracked bodies
        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }
        }

        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                if (!_Bodies.ContainsKey(body.TrackingId))
                {
                    _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }

                RefreshBodyObject(body, _Bodies[body.TrackingId]);
            }
        }
        if (_CoordinateMapper == null)
        {
            _CoordinateMapper = _BodyManager.Sensor.CoordinateMapper;
        }
    }

    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);
        CreateHandsObject(body);
        return body;
    }
   
    
    // Create Hand Objects
    private void CreateHandsObject(GameObject body)
    {
        foreach(var jt in handtypes)
        {
            GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Rigidbody jointObjRigidBody = jointObj.AddComponent<Rigidbody>();
            jointObjRigidBody.mass = 5;

            jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;
        }
    }

    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        foreach(var jt in handtypes)
        {
			Kinect.Joint sourceJoint = body.Joints[jt];
			Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
			jointObj.localPosition = GetVector3FromJoint(sourceJoint);
        }
    }

    private Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        var valid = joint.TrackingState != Kinect.TrackingState.NotTracked;
        if (ConvertCamera != null || valid)
        {
            // KinectのCamera座標系(三次元)をColor座標系(2次元)に変換する
            var point = _CoordinateMapper.MapCameraPointToColorSpace(joint.Position);
            var point2 = new Vector3(point.X, point.Y, 0);
            if ((0 <= point2.x) && (point2.x < _KinectWidth) && (0 <= point2.y) && (point2.y < _KinectHeight))
            {

                // スクリーンサイズで調整(Kinect->Unity)
                point2.x = point2.x * Screen.width / _KinectWidth;
                point2.y = point2.y * Screen.height / _KinectHeight;

                // Unityのワールド座標系(三次元)に変換
                var colorPoint3 = ConvertCamera.ScreenToWorldPoint(point2);

                //座標の調整
                colorPoint3.y *= -1;
                colorPoint3.z = -1;

                return colorPoint3;
            }
        }
        return new Vector3(joint.Position.X * 10,
                            joint.Position.Y * 10,
                            -1);
    }
}
