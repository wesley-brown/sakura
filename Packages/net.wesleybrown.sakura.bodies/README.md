# Sakura Bodies
A component that contains systems related to bodies.

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
  - [Register Body System](#registerbodysystem)
  - [Collidable Movement System](#collidablemovementsystem)

## Installation
The Sakura Bodies component is currently included in the Sakura project's
repository: https://github.com/wesley-brown/sakura.

## Usage
This component provides various systems related to bodies. In Sakura, a body is
a representation of an entity that occupies physical space in the simulation.
Each system follows the Clean Architecture concept of plugins
(https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

There are two systems available: the Collidable Movement System and
the Register Body System. Regardless of which system you want to plug into, you
need to create a BodiesComponent instance. The same BodiesComponent instance
should be used across an entire application and passed to any components that
use the Sakura Bodies component.

An example of creating a BodiesComponent is:
```cs
internal BodiesComponent Create()
{
  var movementSpeeds = new Dictionary<Guid, float>();
  var bodies = new Dictionar<Guid, Vector3>();
  var gameObjects = new Dictionary<Guid, GameObject>();
  return new BodiesComponent(
    movementSpeeds,
    bodies,
    gameObjects);
}
```

### Register Body System
The Register Body System is defined in the RegisterBody namespace. This
namespace provides four public classes that need to be used to plug into the
Register Body System: System, Input, Presenter, and Output. The combination
of System and Input defines the input port of this sytem. The combination of
Presenter and Output defines the output port of this system. The
BodiesComponent provides a RegisterBodySystem factory method that can be used
to create an implementation of the RegisterBody.System interface that can
then be used.

An example of implementing the RegisterBody.Presenter interface is:
```cs
public void Present(Output output)
{
  Debug.Log("Body successfully registered.");
}

public void PresentInputErrors(List<string> inputErrors)
{
  foreach (var error in inputErrors)
  {
    Debug.Log(error);
  }
}

public void PresentOutputErrors(List<Exception> outputErrors)
{
  foreach (var error in outputErrors)
  {
    Debug.Log(error.Message);
  }
}
```

### Collidable Movement System
The Collidable Movement System is defined in the CollidableMovement namespace.
This namesapce provides four public classes that need to be used to plug into
it: BodiesComponent, MovementSystem, CollidableMovementSystemPresenter, and
CollidableMovement. The MovementSystem interface is the input port for this
system. The CollidableMovementSystemPresenter interface is the output port for
this system. The BodiesComponent provides a MovementSystem factory method that
can be used to create an implementation of the MovementSystem interface that
can then be used.

An example of implementing the CollidableMovementSystemPresenter interface is:
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
