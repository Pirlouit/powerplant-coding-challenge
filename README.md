# powerplant-coding-challenge

This is my implementation of the [powerplant-coding challenge](https://github.com/gem-spaas/powerplant-coding-challenge) from [ENGIE](https://www.engie.com/).

The goal of this coding challenge is to calculate how much power each of a multitude of different powerplants need to produce (a.k.a. the production-plan) when the load is given and taking into account the cost of the underlying energy sources (gas, kerosine) and the Pmin and Pmax of each powerplant. The load is the continuous demand of power. The total load at each moment in time is forecasted. For instance for Belgium you can see the load forecasted by the grid operator here.

At any moment in time, all available powerplants need to generate the power to exactly match the load. The cost of generating power can be different for every powerplant and is dependent on external factors: The cost of producing power using a turbojet, that runs on kerosine, is higher compared to the cost of generating power using a gas-fired powerplant because of gas being cheaper compared to kerosine and because of the thermal efficiency of a gas-fired powerplant being around 50% (2 units of gas will generate 1 unit of electricity) while that of a turbojet is only around 30%. The cost of generating power using windmills however is zero. Thus deciding which powerplants to activate is dependent on the merit-order.

When deciding which powerplants in the merit-order to activate (a.k.a. unit-commitment problem) the maximum amount of power each powerplant can produce (Pmax) obviously needs to be taken into account. Additionally gas-fired powerplants generate a certain minimum amount of power when switched on, called the Pmin.

## Prerequisites

- Visual Studio 2022 or higher
- .NET 6.x SDK
- Docker (optionnal)

## Installing

- Clone the project running `git clone https://github.com/Pirlouit/powerplant-coding-challenge.git`

## Running

- From Visual Studio: Open the solution within Visual Studio and run it.
- With Docker: `docker-compose up`

You can now open your browser at <http://localhost:8888/swagger/index.html> to explore the API throught the [Swagger](https://swagger.io/) UI.

The endpoint is located at <http://localhost:8888/productionplan> as asked in the challenge.

## Tests

Open your browser at <http://localhost:8888/swagger/index.html> and test the endpoint throught the Swagger interface. To do so, follow these instrutctions:

- Open the `POST /productionplan` endpoint
- Click on the `Try it out` button
- Copy the content of one of the `payloadX.json` file located in the `/example-payloads` folder and paste it in the `Request body` field
- Then press the `Execute` button
- The result should be displayed in the `Response body` field
