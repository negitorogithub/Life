using NUnit.Framework;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayModeTest
    {
        const string testSceneName = "TestScene";
        private const string unitName = "Unit1";
        private GameObject unitObject;
        private const string feedName = "Feed";
        private GameObject feedObject;
        private const string masterDataName = "MasterData";
        private GameObject masterDataObject;



        [OneTimeSetUp]
        public void Initialize()
        {
            Time.timeScale = 3;
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [SetUp]
        public void Reset()
        {
            SceneManager.LoadSceneAsync(testSceneName).completed += _ => {
                unitObject = GameObject.Find(unitName);
                feedObject = GameObject.Find(feedName);
                masterDataObject = GameObject.Find(masterDataName);
            };
        }

        [UnityTest]
        public IEnumerator UnitExistence()
        {
            Assert.That(unitObject != null);
            yield return null;
        }
        [UnityTest]
        public IEnumerator UnitComponetsExistence()
        {
            Assert.That(unitObject.GetComponent<HpHolder>() != null);
            Assert.That(unitObject.GetComponent<IMovable>() != null);
            Assert.That(unitObject.GetComponent<IEats>() != null);
            yield return null;
        }

        [UnityTest]
        public IEnumerator FeedExistence()
        {
            Assert.That(feedObject != null);
            yield return null;
        }

        [UnityTest]
        public IEnumerator FeedComponetsExistence()
        {
            Assert.That(feedObject.GetComponent<IFeed>() != null);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MasterDataExistence()
        {
            Assert.That(masterDataObject != null);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableStop()
        {
            var movable = unitObject.GetComponent<IMovable>();
            Assert.That(movable.StateReactive.Value == MovingState.STOPPING);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableMove2Target()
        {
            var movable = unitObject.GetComponent<IMovable>();
            float distance = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            movable.Move2(feedObject);
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_2_TARGET);
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            float distance_ = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            Assert.That(distance_ < distance);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableMoveAwayFromTarget()
        {
            var movable = unitObject.GetComponent<IMovable>();
            float distance = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            movable.MoveAwayFrom(feedObject);
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_AWAY_FROM_TARGET);
            float distance_ = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            Assert.That(distance_ > distance);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableMoveRandomly()
        {
            var movable = unitObject.GetComponent<IMovable>();
            float distance = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            movable.MoveRandomly();
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_RANDOMLY);
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            float distance_ = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            Assert.That(distance_ != distance);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableStopAfterMove()
        {
            var movable = unitObject.GetComponent<IMovable>();
            movable.Move2(feedObject);
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_2_TARGET);
            movable.Stop();
            Assert.That(movable.StateReactive.Value == MovingState.STOPPING);
            movable.MoveAwayFrom(feedObject);
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_AWAY_FROM_TARGET);
            movable.Stop();
            Assert.That(movable.StateReactive.Value == MovingState.STOPPING);
            movable.MoveRandomly();
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_RANDOMLY);
            movable.Stop();
            Assert.That(movable.StateReactive.Value == MovingState.STOPPING);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableSpeedAbsolute()
        {
            var movable = unitObject.GetComponent<IMovable>();
            var speed = masterDataObject.GetComponent<IMasterData>().Speed;
            movable.Move2(feedObject);
            Assert.That(movable.StateReactive.Value == MovingState.MOVING_2_TARGET);
            float distance = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            yield return new WaitForFixedUpdate();
            var time = Time.fixedTime;
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            var time_ = Time.fixedTime;
            float distance_ = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            Assert.That(Mathf.Abs( distance - distance_ - speed * (time_ - time)) < 0.05);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitMovableSpeedRelative()
        {
            var movable = unitObject.GetComponent<IMovable>();

            var speed = masterDataObject.GetComponent<IMasterData>().Speed;
            movable.Move2(feedObject);
            float distance = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            float distance_ = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            float slowMoved = distance - distance_;
            movable.Stop();
            yield return new WaitForFixedUpdate();

            masterDataObject.GetComponent<IMasterData>().Speed *= 3;
            movable.Move2(feedObject);
            float distanceQ = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            float distance_Q = Vector3.Distance(feedObject.transform.position, unitObject.transform.position);
            float quickMoved = distanceQ - distance_Q;
            movable.Stop();
            yield return new WaitForFixedUpdate();

            Assert.That(Mathf.Abs(slowMoved - quickMoved / 3) < 0.05);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator UnitIEats()
        {
            var eats = unitObject.GetComponent<IEats>();
            var movable = unitObject.GetComponent<IMovable>();
            var hasEeated = false;
            movable.Move2(feedObject);
            var disposable = eats.EatedSubject.Subscribe(obj =>
            {
                Assert.That(obj == feedObject);
                hasEeated = true;
                Assert.That(feedObject == null);

            });
            while (hasEeated)
            {
                yield return null;
            }
            disposable.Dispose();
            yield return null;
        }


    }
}
