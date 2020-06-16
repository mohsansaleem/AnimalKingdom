# AnimalKingdom

This is a simple farm game with the raw UI. Primary purpose of this project was to implement an expandable architecture. 

##### Highlights:
  - Unity 2019.4.0f1
  - MVP
  - Dependency Injection
  - Reactive Programing
  - Promises
  - State Machine
  - Generic Popup System
  - Generic Pooling System

#### Installation
  - Pull the code.
  - Use Unity 2019.4.0f1 to open it.
  - Check /MainMenu/Game/Always Start from Startup Scene.
  - Press Play.

#### Hierarchy Overview:
  - All the Context code is in __\Assets\Scripts\AnimalKingdon\Contexts__. Each scene has the respective folders including some extra scenes like Popup and MainHub etc.
  - All the views code is in __\Assets\Scripts\AnimalKingdon\Views__. Each scene has the respective folders.
  - __GamePlay__ scene has all the __magic__. Especially the Gathering state.
  - __Bootstrap__ is the starting scene.
  - __*Data__ files\classes are for __Metadata__ objects.
  - __*RemoteData__ files/classes are for __GameState__ objects and I am linking the *Data on loading of GameState.
  - __*RemoteDataModel__ are the Models that contain __RemoteData__ and other reactive properties and collections.
  - __\Assets\Scripts\Core__ is __submodule__ that contains just the abstract of some generics that can be shared across the project so I have added it to minimise my work.
  - All the __Scenes__ are in __\Assets\__Scenes__ folder and __respective resources__ are in __\Assets\Resources\Scenes__.
  - Main __Game code__ is in __\Assets\Scripts\AnimalKingdon__.
  - (__Models__, __RemoteData__ and __Data__)__s__ are in __\Assets\Scripts\AnimalKingdon\Models__.
  - All the __Commands__ are in   __\Assets\Scripts\AnimalKingdon\Commands__.


#### Information:
Delete the /Assets/StreamingAssets/GameState.json & MetaData.json if you want to change the default setting after updating Scriptable Objects.
Meta is not balanced. So you will have to manage.


| Plugins | Description |
| ------ | ------ |
|[Unity3D] | [3D Game Engine.][GE]|
| [Zenject] | [Dependency Injection.][DE] |
| [UniRx] | [Reactive Programming.][RP] |
| [C# Promises] | [Asynchronous coding.][AC] |




**Happy Day!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)


   [Unity3D]: <https://unity.com/releases/2019-lts>
   [Zenject]: < https://github.com/svermeulen/Zenject>
   [UniRx]: <https://github.com/neuecc/UniRx>
   [C# Promises]: <https://github.com/Real-Serious-Games/C-Sharp-Promise>
   [Spine]: <http://esotericsoftware.com/>

   [GE]: <https://en.wikipedia.org/wiki/Game_engine>
   [DE]: <https://en.wikipedia.org/wiki/Dependency_injection>
   [RP]: <https://en.wikipedia.org/wiki/Reactive_programming>
   [AC]: <http://www.what-could-possibly-go-wrong.com/promises-for-game-development/#introduction-to-promises>
   [SP]: <http://esotericsoftware.com/blog>

