## Introduction

[![Join the chat at https://gitter.im/Ruhrpottpatriot/GW2.NET](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Ruhrpottpatriot/GW2.NET?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
So, what is this project all about?
We aim to provide all .NET developers an easy to use, well documented library and tools to use in their own applications using Guild Wars 2 data. The goal is to provide the developers with an entry point to the api service, without having to piece the scattered information together for themselves. While the /V2/ nodes have made live mauch easier, there is still work to do and we take (msot) of it off your back!

Currently this wrapper is the most complete .NET implementation out there and of the writing of this readme the most complete of all. We are a bit proud of that.

Without further ado, happy coding and see you ingame folks!

## Prerequisites
 - **Windows:** .NET 4.5+

## Online resources
 - [NuGet package][nuget] (Requires NuGet 2.7+)
 - [Source code][source]

 [nuget]: https://www.nuget.org/packages/GW2NET/
 [source]: https://github.com/Ruhrpottpatriot/gw2dotnet

## Troubleshooting and support

 - Usage or programming related question? Open an issue on the [issue tracker][tracker]
 - Found a bug or missing a feature? Feed the [issue tracker][tracker]

[tracker]: https://github.com/Ruhrpottpatriot/gw2dotnet/issues


|  | Windows (x86/amd64) |
| :------ | :------: |
| **master** | [![master win][master-win-badge]][master-win] |

[appveyor]: http://appveyor.com/

[master-win-badge]: https://ci.appveyor.com/api/projects/status/jgtvrg532cera58c/branch/master?svg=true
[master-win]: https://ci.appveyor.com/project/Ruhrpottpatriot/gw2dotnet/branch/master

## Quick contributing guide

 - Fork and clone locally
 - Create a topic specific branch. Add some nice feature. Do not forget the tests ;-)
 - Send a Pull Request to spread the fun!

 More thorough information available in the [wiki][wiki].

 [wiki]: https://github.com/Ruhrpottpatriot/gw2dotnet/wiki


## Implementation Progress
 Below is a compatibility matrix of API endpoints and other features.

| Feature                         | Supported | Planned | NuGet Package                                                                 |
| :------                         | :------:  | :------: |:------:                                                                      |
| `/v1/build.json`                | ✔         |         | [![V1 Builds NuGet][v1-nuget-builds-badge]][v1-nuget-builds]                  |
| `/v1/event_names.json`          | ✔         |         | [![V1 Event Names][v1-nuget-events-badge]][v1-nuget-events]                   |
| `/v1/map_names.json `           | ✔         |         | [![V1 Map Names][v1-nuget-maps-badge]][v1-nuget-maps]                         |  
| `/v1/world_names.json `         | ✔         |         | [![V1 World Names][v1-nuget-worlds-badge]][v1-nuget-worlds]                   |
| `/v1/event_details.json `       | ✔         |         | [![V1 Event Details][v1-nuget-events-badge]][v1-nuget-events]                 |
| `/v1/guild_details.json `       | ✔         |         | [![V1 Guilds][v1-nuget-guilds-badge]][v1-nuget-guilds]                        |
| `/v1/items.json `               | ✔         |         | [![V1 Items][v1-nuget-items-badge]][v1-nuget-items]                           |
| `/v1/item_details.json `        | ✔         |         | [![V1 Item Details][v1-nuget-items-badge]][v1-nuget-items]                    |
| `/v1/recipes.json `             | ✔         |         | [![V1 Recipes][v1-nuget-recipes-badge]][v1-nuget-recipes]                     |
| `/v1/recipe_details.json `      | ✔         |         | [![V1 Recipe Details][v1-nuget-recipes-badge]][v1-nuget-recipes]              |
| `/v1/skins.json `               | ✔         |         | [![V1 Skins][v1-nuget-skins-badge]][v1-nuget-skins]                           |
| `/v1/skin_details.json `        | ✔         |         | [![V1 Skin Details][v1-nuget-skins-badge]][v1-nuget-skins]                    |
| `/v1/continents.json `          | ✔         |         | [![V1 Continents][v1-nuget-continents-badge]][v1-nuget-continents]            |
| `/v1/maps.json `                | ✔         |         | [![V1 Maps][v1-nuget-maps-badge]][v1-nuget-maps]                              |
| `/v1/map_floor.json `           | ✔         |         | [![V1 Maps][v1-nuget-maps-badge]][v1-nuget-maps]                              |
| `/v1/wvw/matches.json `         | ✔         |         | [![V1 WvW Matches][v1-nuget-matches-badge]][v1-nuget-matches]                 |
| `/v1/wvw/match_details.json `   | ✔         |         | [![V1 WvW Match Details][v1-nuget-matches-badge]][v1-nuget-matches]           |
| `/v1/wvw/objective_names.json ` | ✔         |         | [![V1 WvW Objective Details][v1-nuget-objectives-badge]][v1-nuget-objectives] |
| `/v2/quaggans.json `            | ✔         |         | [![V2 Quaggans][v2-nuget-quaggans-badge]][v2-nuget-quaggans]                  |
| `/v2/commerce/exchange`         | ✔         |         | [![V2 Exchange][v2-nuget-exchange-badge]][v2-nuget-exchange]                  |
| `/v2/commerce/listings`         | ✔         |         | [![V2 Listings][v2-nuget-listings-badge]][v2-nuget-listings]                  |
| `/v2/commerce/prices`           | ✔         |         | [![V2 Prices][v2-nuget-prices-badge]][v2-nuget-prices]                        |
| `/v2/items`                     | ✔         |         | [![V2 Items][v2-nuget-items-badge]][v2-nuget-items]                           |
| `/v2/recipes`                   | ✔         |         | [![V2 Recipes][v2-nuget-recipes-badge]][v2-nuget-recipes]                     |
| `/v2/recipes/search`            | ✔         |         | [![V2 Recipe Search][v2-nuget-recipes-badge]][v2-nuget-recipes]               |
| `/v2/worlds`                    | ✔         |         | [![V2 Wolds][v2-nuget-worlds-badge]][v2-nuget-worlds]                         |
| `/v2/build`                     | ✔         |         | [![V2 Builds][v2-nuget-build-badge]][v2-nuget-build]                          |
| `/v2/files`                     | ✔         |         | [![V2 Files][v2-nuget-files-badge]][v2-nuget-files]                           |
| `/v2/colors`                    | ✔         |         | [![V2 Colors][v2-nuget-colors-badge]][v2-nuget-colors]                        |
| `/v2/continents`                | ✔         |         | [![V2 Continents][v2-nuget-continents-badge]][v2-nuget-continents]            |
| `/v2/continents/:id/floors`     |           | ✔       |                                                                               |
| `/v2/skins`                     | ✔         |         | [![V2 Skins][v2-nuget-skins-badge]][v2-nuget-skins]                           |
| `/v2/maps`                      | ✔         |         | [![V2 Maps][v2-nuget-maps-badge]][v2-nuget-maps]                              |
| `render.guildwars2.com`         | ✔         |         | [![Render][v2-nuget-maps-badge]][v2-nuget-main]                               |
| MumbleLink                      | ✔         |         | [![Mumble][v2-nuget-mumble-badge]][v2-nuget-mumble]                           |
| `/v2/account`                   |           | ✔       |                                                                               |
| `/v2/account/bank`              |           | ✔       |                                                                               |
| `/v2/account/materials`         |           | ✔       |                                                                               |
| `/v2/characters`                |           | ✔       |                                                                               |
| `/v2/characters/:id/equipment`  |           | ✔       |                                                                               |
| `/v2/characters/:id/inventory`  |           | ✔       |                                                                               |
| `/v2/commerce/transactions`     |           | ✔       |                                                                               |
| `/v2/events`                    |           | ✔       |                                                                               |
| `/v2/events-state`              |           | ✔       |                                                                               |
| `/v2/guild/:id`                 |           | ✔       |                                                                               |
| `/v2/guild/:id/inventory`       |           | ✔       |                                                                               |
| `/v2/guild/:id/members`         |           | ✔       |                                                                               |
| `/v2/guild/:id/ranks`           |           | ✔       |                                                                               |
| `/v2/guild/permissions`         |           | ✔       |                                                                               |
| `/v2/guild/upgrades`            |           | ✔       |                                                                               |
| `/v2/leaderboards`              |           | ✔       |                                                                               |
| `/v2/materials`                 |           | ✔       |                                                                               |
| `/v2/skills`                    |           | ✔       |                                                                               |
| `/v2/wvw/matches`               |           | ✔       |                                                                               |
| `/v2/wvw/objectives`            |           | ✔       |                                                                               | |

[v1-nuget-builds-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Builds.svg
[v1-nuget-builds]:https://www.nuget.org/packages/GW2NET.V1.Builds
[v1-nuget-events-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Events.svg
[v1-nuget-events]:https://www.nuget.org/packages/GW2NET.V1.Events
[v1-nuget-maps-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Maps.svg
[v1-nuget-maps]:https://www.nuget.org/packages/GW2NET.V1.Maps
[v1-nuget-worlds-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Worlds.svg
[v1-nuget-worlds]:https://www.nuget.org/packages/GW2NET.V1.Worlds
[v1-nuget-events-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Events.svg|/
[v1-nuget-events]:https://www.nuget.org/packages/GW2NET.V1.Events
[v1-nuget-guilds-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Guilds.svg
[v1-nuget-guilds]:https://www.nuget.org/packages/GW2NET.V1.Guilds
[v1-nuget-items-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Items.svg
[v1-nuget-items]:https://www.nuget.org/packages/GW2NET.V1.Items
[v1-nuget-recipes-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Recipes.svg
[v1-nuget-recipes]:https://www.nuget.org/packages/GW2NET.V1.Recipes
[v1-nuget-skins-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Skins.svg
[v1-nuget-skins]:https://www.nuget.org/packages/GW2NET.V1.Skins
[v1-nuget-continents-badge]:https://img.shields.io/nuget/v/GW2NET.V1.Continents.svg
[v1-nuget-continents]:https://www.nuget.org/packages/GW2NET.V1.Continents
[v1-nuget-maps]:https://img.shields.io/nuget/v/GW2NET.V1.Maps.svg
[v1-nuget-maps]:https://www.nuget.org/packages/GW2NET.V1.Maps
[v1-nuget-matches-badge]:https://img.shields.io/nuget/v/GW2NET.V1.WorldVersusWorld.Matches.svg
[v1-nuget-matches]:https://www.nuget.org/packages/GW2NET.V1.WorldVersusWorld.Matches
[v1-nuget-objectives-badge]:https://img.shields.io/nuget/v/GW2NET.V1.WorldVersusWorld.Objectives.svg
[v1-nuget-objectives]:https://www.nuget.org/packages/GW2NET.V1.WorldVersusWorld.Objectives

[v2-nuget-quaggans-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Quaggans.svg
[v2-nuget-quaggans]:https://www.nuget.org/packages/GW2NET.V2.Quaggans
[v2-nuget-exchange-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Commerce.Exchange.svg
[v2-nuget-exchange]:https://www.nuget.org/packages/GW2NET.V2.Commerce.Exchange
[v2-nuget-listings-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Commerce.Listings.svg
[v2-nuget-listings]:https://www.nuget.org/packages/GW2NET.V2.Commerce.Listings
[v2-nuget-prices-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Commerce.Prices.svg
[v2-nuget-prices]:https://www.nuget.org/packages/GW2NET.V2.Commerce.Prices
[v2-nuget-items-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Items.svg
[v2-nuget-items]:https://www.nuget.org/packages/GW2NET.V2.Items
[v2-nuget-recipes-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Recipes.svg
[v2-nuget-recipes]:https://www.nuget.org/packages/GW2NET.V2.Recipes
[v2-nuget-worlds-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Worlds.svg
[v2-nuget-worlds]:https://www.nuget.org/packages/GW2NET.V2.Worlds
[v2-nuget-build-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Builds.svg
[v2-nuget-build]:https://www.nuget.org/packages/GW2NET.V2.Builds
[v2-nuget-files-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Files.svg
[v2-nuget-files]:https://www.nuget.org/packages/GW2NET.V2.Files
[v2-nuget-colors-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Colors.svg
[v2-nuget-colors]:https://www.nuget.org/packages/GW2NET.V2.Colors
[v2-nuget-continents-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Continents.svg
[v2-nuget-continents]:https://www.nuget.org/packages/GW2NET.V2.Continents
[v2-nuget-skins-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Skins.svg
[v2-nuget-skins]:https://www.nuget.org/packages/GW2NET.V2.Skins
[v2-nuget-maps-badge]:https://img.shields.io/nuget/v/GW2NET.V2.Maps.svg
[v2-nuget-maps]:https://www.nuget.org/packages/GW2NET.V2.Maps
[v2-nuget-main-badge]:https://img.shields.io/nuget/v/GW2NET.svg
[v2-nuget-main]:https://www.nuget.org/packages/GW2NET
[v2-nuget-mumble-badge]:https://img.shields.io/nuget/v/GW2NET.MumbleLink.svg
[v2-nuget-mumble]:https://www.nuget.org/packages/GW2NET.MumbleLink

## Spotlight

Below is a list of known projects that use GW2.NET. Want your project added to this list? Send us a message!

### GW2 Personal Assistant Overlay
Project page: ~~https://gw2pao.codeplex.com/~~ https://github.com/SamHurne/gw2pao


## (Somewhat) Important Links
* You can find the official thread on the Guild Wars 2 [here](http://is.gd/dLEf4d)
