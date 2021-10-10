# Sakura Bodies

A component that contains systems related to bodies.

## Installation

The Sakura Bodies component is currently included in the Sakura project's 
repository: https://github.com/wesley-brown/sakura.

## Usage

This component provides various systems related to bodies. In Sakura, a body is 
a representation of an entity that occupies physical space in the simulation. 
Each system follows the Clean Architecture concept of plugins 
(https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html). 

Currently, the only system provided by the Sakura Bodies component is the 
collidable movement system. The steps for how to plug into each system are 
provided below.

### Collidable Movement System

The Collidable Movement System provides four public classes that need to be 
used to plug into it: BodiesComponent, MovementSystem, 
CollidableMovementSystemPresenter, and CollidableMovement. The MovementSystem 
interface is the input port for this system. The 
CollidableMovementSystemPresenter interface is the output port for this system. 
The BodiesComponent provides a MovementSystem factory method that can be used 
to create an implementation of the MovementSystem interface that can then be 
used.

For this example, we will use a single MonoBehaviour called MoveEntity to plug 
into the CollidableMovementSystem. First, we need to implement the 
CollidableMovementSystemPresenter interface:

```cs
public void ReportError(string error)
{
    Debug.Log(error);
}

public void Present(CollidableMovement collidableMovement)
{
    transform.position = collidableMovement.EndlingLocation;
}
```

Then, we need to create a BodiesComponent instance. A BodiesComponent requires 
three dictionaries that will be used by all the systems inside this component 
and a CharacterController used specifically by the CollidableMovement system:

```cs
private Guid entity;
private BodiesComponent bodiesComponent;
private CharacterController characterController;

private void Start()
{
    // Entities in Sakura are represented by a GUID
    entity = new Guid("4ffc0096-52c0-4a02-85ca-106062ea2fb9");
    var movementSpeeds = new Dictionary<Guid, float>{
        { entity, 0.0608f } // Measured in meters / tick
    };
    var bodies = new Dictionary<Guid, Vectore>{
        { entity, gameObject.transform.position }
    };
    var gameObjects = new Dictionary<Guid, GameObject>{
        { entity, gameObject }
    };
    bodiesComponent = new BodiesComponent(
        movementSpeeds,
        bodies,
        gameObjects);
    characterController = GetComponent<CharacterController>();
}
```

Then, we can use the MovementSystem factory method on BodiesComponent to create 
a Collidable Movement System and use it to move our entity:

```cs
private void FixedUpdate()
{
    var destination = GetVector3DestinationToMoveTo();
    var movementSystem = bodiesComponent.MovementSystem(
      characterController,
      this);
    movementSystem.MoveEntityTowardsDestination(
      entity,
      destination);
}
```

Note that the call to MovementSystem.MoveEntityTowardsDestination returns void 
and is therefore just us passing data to the Collidable Movement System through 
its input port. The data the CollidableMovementSystem will give back to us 
comes through its output port via the CollidableMovementSystemPresenter methods 
we implemented earlier.

This is how our MonoBehaviour looks now:

```cs
public sealed class MoveEntity 
    : MonoBehaviour, CollidableMovementSystemPresenter
{
    private Guid entity;
    private BodiesComponent bodiesComponent;
    private CharacterController characterController;

    private void Start()
    {
        // Entities in Sakura are represented by a GUID
        entity = new Guid("4ffc0096-52c0-4a02-85ca-106062ea2fb9");
        var movementSpeeds = new Dictionary<Guid, float>{
            { entity, 0.0608f } // Measured in meters / tick
        };
        var bodies = new Dictionary<Guid, Vectore>{
            { entity, gameObject.transform.position }
        };
        var gameObjects = new Dictionary<Guid, GameObject>{
            { entity, gameObject }
        };
        bodiesComponent = new BodiesComponent(
            movementSpeeds,
            bodies,
            gameObjects);
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        var destination = GetVector3DestinationToMoveTowards();
        var movementSystem = bodiesComponent.MovementSystem(
          characterController,
          this);
        movementSystem.MoveEntityTowardsDestination(
          entity,
          destination);
    }

    public void ReportError(string error)
    {
        Debug.Log(error);
    }

    public void Present(CollidableMovement collidableMovement)
    {
        transform.position = collidableMovement.EndlingLocation;
    }
}
```

Although we implemented the output port (CollidableMovementSystemPresenter) on 
the same class that used the input port in this example, we could instead do 
that in a separate component that can also interpolate our position between 
frames in the Update method for example.

Note that we do not have access to any concrete implementation of the 
MovementSystem interface input port. Instead, we can only use the one that the 
BodiesComponent's factory methods provide us.
