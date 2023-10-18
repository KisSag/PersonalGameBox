using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolygonGenerator : MonoBehaviour
{
    #region setup
    //mesh properties
    Mesh mesh;
    Rigidbody2D myRigi;
    [SerializeField] Vector3[] polygonPoints;
    [SerializeField] int[] polygonTriangles;

    //polygon properties
    [SerializeField] int polygonSides;
    [SerializeField] float polygonRadiusMax;
    float polygonRadius;
    [SerializeField] GameObject platform;

    PolygonCollider2D myPolygon;
    float vertexRandomRangeMax;



    //bool canchange = true;
    void Start()
    {

        

        gameObject.tag = "RockPreSet";
        gameObject.layer = LayerMask.NameToLayer("ObserveObject");
        polygonSides = (int)UnityEngine.Random.Range(4, polygonSides);
        polygonRadius = UnityEngine.Random.Range(0.5f, polygonRadiusMax);

        myRigi = GetComponent<Rigidbody2D>();
        myRigi.mass = 10f * (polygonRadius / polygonRadiusMax);

        mesh = new Mesh();
        vertexRandomRangeMax = polygonRadius / 3;
        myPolygon = GetComponent<PolygonCollider2D>();
        this.GetComponent<MeshFilter>().mesh = mesh;

        DrawFilled(polygonSides, polygonRadius);
        drawPolygonCollider(polygonPoints);


    }

    void Update()
    {
        rockDestroyCheck();

    }


    void rockDestroyCheck()
    {
        if(this.transform.position.y < platform.transform.position.y - 5f)
        {
            Destroy(this.gameObject);
        }
    }

    //this method create polygon collider for the shape 这个方法绘制了图形的多边形碰撞器
    void drawPolygonCollider(Vector3[] polygonPoints)
    {
        Vector2[] polygonPoints2D = new Vector2[polygonPoints.Length];
        for(int i = 0; i < polygonPoints.Length; i++)
        {
            polygonPoints2D[i] = polygonPoints[i];
        }

        myPolygon.SetPath(0, polygonPoints2D);
    }

    #endregion

    //this method draw thte total polygon 这个方法绘制完整的图形
    void DrawFilled(int sides, float radius)
    {
        polygonPoints = GetCircumferencePoints(sides, radius).ToArray();
        
        polygonPoints = randomizePoints(polygonPoints);

        polygonTriangles = DrawFilledTriangles(polygonPoints);
        mesh.Clear();
        mesh.vertices = polygonPoints;
        mesh.triangles = polygonTriangles;
    }

    Vector3[] randomizePoints(Vector3[] points)
    {
        for(int i = 0; i < points.Count(); i += 1)
        {
            points[i].x = points[i].x + UnityEngine.Random.Range(-vertexRandomRangeMax, vertexRandomRangeMax);
            points[i].y = points[i].y + UnityEngine.Random.Range(-vertexRandomRangeMax, vertexRandomRangeMax);
        }
        return points;
    }

    //this method calculate the location of points 这个方法计算图形的顶点并储存至列表中
    List<Vector3> GetCircumferencePoints(int sides, float radius)
    {
        List<Vector3> points = new List<Vector3>();
        float circumferenceProgressPerStep = (float)1 / sides;
        float TAU = 2 * Mathf.PI;
        float radianProgressPerStep = circumferenceProgressPerStep * TAU;

        for (int i = 0; i < sides; i++)
        {
            float currentRadian = radianProgressPerStep * i;
            points.Add(new Vector3(Mathf.Cos(currentRadian) * radius, Mathf.Sin(currentRadian) * radius, 0));
        }

        return points;
    }

    

    //this method use point to draw the mesh with triangle 此方法使用顶点列表生成三角形网格
    int[] DrawFilledTriangles(Vector3[] points)
    {
        int triangleAmount = points.Length - 2;
        List<int> newTriangles = new List<int>();
        for (int i = 0; i < triangleAmount; i++)
        {
            newTriangles.Add(0);
            newTriangles.Add(i + 2);
            newTriangles.Add(i + 1);
        }
        return newTriangles.ToArray();
    }
}