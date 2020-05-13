using NUnit.Framework;
using System;
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
        private IMasterData masterData;



        [OneTimeSetUp]
        public void Initialize()
        {
            Time.timeScale = 10;
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
                masterData = masterDataObject?.GetComponent<IMasterData>();
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
            var speed = masterData.Speed;
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

            var speed = masterData.Speed;
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

            masterData.Speed *= 3;
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

            Assert.Less(Mathf.Abs(slowMoved - quickMoved / 3) , 0.05);

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
                Assert.AreEqual(obj ,feedObject);
                hasEeated = true;
                Assert.NotNull(feedObject);

            });
            while (hasEeated)
            {
                yield return null;
            }
            disposable.Dispose();
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitHpHolder()
        {
            var hpHolder= unitObject.GetComponent<HpHolder>();
            Assert.AreEqual(hpHolder.maxHp, masterData.UnitHp);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitHpLogicLivingAbsolute()
        {
            var hpLogic  = unitObject.GetComponent<HpLogic>();
            Assert.AreEqual(hpLogic.LivingHpDecrease(1), masterData.LivingHpDecreasePerSecond);
            Assert.AreEqual(hpLogic.MovingHpDecrease(1), masterData.MovingHpDecreasePerMeter);
            var hp = hpLogic.hpHolder.hp;
            var time = Time.time;
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }
            var hp_ = hpLogic.hpHolder.hp;
            var time_ = Time.time;
            var expectedHpDelta = ( time_ - time ) * masterData.LivingHpDecreasePerSecond;
            Assert.AreEqual(1,( hp - hp_ )/ expectedHpDelta, 0.1);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitHpLogicLivingRelative()
        {
            var hpLogic = unitObject.GetComponent<HpLogic>();
            hpLogic.LivingHpDecrease(1);

            var hp = hpLogic.hpHolder.hp;
            var time = Time.time;
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }
            var hp_ = hpLogic.hpHolder.hp;
            var time_ = Time.time;
            var hpDecreasedRatio = (hp - hp_)/(time_ - time);

            masterData.LivingHpDecreasePerSecond *= 3;
            var hpQ = hpLogic.hpHolder.hp;
            var timeQ = Time.time;
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }
            var hpQ_ = hpLogic.hpHolder.hp;
            var timeQ_ = Time.time;
            var hpDecreasedRatioQ = (hpQ - hpQ_)/(timeQ_ - timeQ);

            Assert.AreEqual(1, (hpDecreasedRatioQ/3)/ hpDecreasedRatio, 0.1);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitHpLogicMovingAbsolute()
        {
            var hpLogic = unitObject.GetComponent<HpLogic>();
            unitObject.GetComponent<IMovable>().MoveAwayFrom(feedObject);
            yield return new WaitForFixedUpdate();
            var time = Time.time;
            var hp = hpLogic.hpHolder.hp;

            var velocityScala = unitObject.GetComponent<Rigidbody>().velocity.magnitude;
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }
            var hp_ = hpLogic.hpHolder.hp;
            var time_ = Time.time;
            var hpDelta = hp - hp_;
            var livingHpDelta = ( time_ - time ) * masterData.LivingHpDecreasePerSecond;
            var movingHpDelta = hpDelta - livingHpDelta;
            var expectedMovingHpDelta =  masterData.MovingHpDecreasePerMeter * velocityScala * ( time_ - time );
            Assert.AreEqual(1, movingHpDelta/expectedMovingHpDelta, 0.1);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UnitHpLogicEatAbsolute()
        {
            var hpLogic = unitObject.GetComponent<HpLogic>();
            var hp = hpLogic.hpHolder.hp;
            hpLogic.IEatsObject.GetComponent<IEats>().EatedSubject.OnNext(null);
            var hp_ = hpLogic.hpHolder.hp;
            var hpDelta = hp_ - hp;
            var expectedHpDelta = masterData.FeedHpIncrease;
            Assert.That(hpDelta, Is.EqualTo(expectedHpDelta));
            yield return null;
        }
    }
}