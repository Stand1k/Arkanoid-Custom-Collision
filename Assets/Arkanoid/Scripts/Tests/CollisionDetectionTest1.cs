using System.Collections;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Arkanoid.Tests
{
    public class CollisionDetectionTest
    {
        [UnityTest]
        public IEnumerator WhenCircleCollider_IntersectRectangleCollider_ThenIntersectShouldBeTrue()
        {
            //Arrange.
            
            GameObject circleColliderGO = new GameObject("circleCollider");
            GameObject rectanleColliderGO = new GameObject("rectCollider");
            
            circleColliderGO.transform.position = new Vector3(2f, 3f, 0f);
            circleColliderGO.transform.localScale = new Vector3(1f, 1f, 0f);

            rectanleColliderGO.transform.position = new Vector3(2f, 3f, 0f);
            rectanleColliderGO.transform.localScale = new Vector3(1f, 1f, 0f);

            rectanleColliderGO.AddComponent<RectangleCollider>();
            circleColliderGO.AddComponent<CircleCollider>();

            //Act.
            
            var circleCollider = circleColliderGO.GetComponent<CircleCollider>();
            var rectCollider = rectanleColliderGO.GetComponent<RectangleCollider>();
            
            yield return new WaitForSeconds(3f);
            
            //Assert
            
            circleCollider.Intersects(rectCollider).Should().BeTrue();
        }
    }
}