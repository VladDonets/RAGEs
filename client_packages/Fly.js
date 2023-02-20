let isFreeFlyEnabled = false;

mp.keys.bind(0x75, false, function() {
    isFreeFlyEnabled = !isFreeFlyEnabled;
    mp.game.player.setSuperJumpThisFrame();
    mp.game.player.setFlying(isFreeFlyEnabled);
});