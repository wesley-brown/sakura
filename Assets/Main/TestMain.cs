using System;
using Sakura.Bodies;
using Sakura.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sakura
{
    sealed class TestMain : MonoBehaviour
    {
        public SakuraBodyDependencies bodyDependencies;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        //private void OnSceneLoad(
        //    Scene scene,
        //    LoadSceneMode mode)
        //{
        //    var gameObjects = scene.GetRootGameObjects();
        //    foreach (var gameObject in gameObjects)
        //    {
        //        var registerSpecificBody = gameObject
        //            .GetComponent<RegisterSpecificBody>();
        //        if (registerSpecificBody)
        //        {
        //            var body = gameObject.GetComponent<Body>();
        //            if (!body)
        //            {
        //                body = gameObject.AddComponent<Body>();
        //                body.entity = new Guid().ToString();
        //            }
        //            var ID = new Guid(body.entity);
        //            Debug.Log(ID);
        //            behaviorsComponent.gameObjects
        //                .Add(
        //                    ID,
        //                    gameObject);
        //        }
        //        else
        //        {
        //            var component = gameObject.AddComponent<RegisterSpecificBody>();
        //            var ID = Guid.NewGuid();
        //            //component.entity = ID.ToString();
        //            component.behaviorsComponent = behaviorsComponent;

        //            behaviorsComponent.gameObjects.Add(
        //                ID,
        //                gameObject);
        //            //Debug.Log($"Registered NON existing game object {gameObject.name} for entity {ID}");
        //        }
        //    }
        //}

        private void OnSceneLoad(
            Scene scene,
            LoadSceneMode mode)
        {
            var gameObjects = scene.GetRootGameObjects();
            foreach (var gameObject in gameObjects)
            {
                var entity = gameObject.GetComponent<SakuraEntity>();
                if (entity)
                {
                    bodyDependencies.gameObjects.Add(
                        new Guid(entity.ID),
                        gameObject);
                    // Temporary until new movement system that doesn't need a
                    // repository of movement speeds is done (each movement
                    // speed will be passed in every call instead).
                    var player = gameObject.GetComponent<TestPlayer>();
                    if (player)
                    {
                        bodyDependencies.movementSpeeds.Add(
                            new Guid(entity.ID),
                            player.movementSpeed);
                    }
                    Debug.Log("Added GameObject for " + gameObject.name);
                }
            }
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
        }
    }
}