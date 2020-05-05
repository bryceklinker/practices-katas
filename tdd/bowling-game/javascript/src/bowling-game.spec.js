import {BowlingGame} from "./bowling-game";

test('something', () => {
    const game = new BowlingGame();

    expect(game.score()).toEqual(0);
});
