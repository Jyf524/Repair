    function Snake() {
        this.rows = 20;
        this.cols = 40;
        this.speed = 200;
        this.currKey = 0;
        this.timer = 0;
        this.sid = "snakeObj" + parseInt(Math.random() * 100000);
        eval(this.sid + "=this");
        this.pos = [];
        this.foodPos = { "x": -1, "y": -1 };
        this.foodNum = 0;
        this.domTab = document.getElementById("map");
        this.pause = 1;
    }
Snake.prototype.init = function () {
    this.map();
    arguments[0] ? this.speed = arguments[0] : false;
    this.pos = [{ "x": 2, "y": 5 }, { "x": 1, "y": 5 }, { "x": 0, "y": 5 }];
    for (j in this.pos) {
        this.domTab.rows[this.pos[j].y].cells[this.pos[j].x].className = "sbody";
    }
    this.domTab.rows[this.pos[0].y].cells[this.pos[0].x].className = "shead";
    this.currKey = 0;
    this.foodNum = 0;
    this.food();
    this.pause = 1;
}
Snake.prototype.trigger = function (e) {
    var e = e || event;
    var eKey = e.keyCode || e.which || e.charCode;
    if (eKey >= 37 && eKey <= 40 && eKey != this.currKey && !((this.currKey == 37 && eKey == 39) || (this.currKey == 38 && eKey == 40) || (this.currKey == 39 && eKey == 37) || (this.currKey == 40 && eKey == 38)) && this.pause == -1) {
        this.currKey = eKey;
    } else if (eKey == 32) {
        this.currKey = (this.currKey == 0) ? 39 : this.currKey;
        ((this.pause *= -1) == -1) ? this.timer = window.setInterval(this.sid + ".move()", this.speed) : window.clearInterval(this.timer);
    }
};
Snake.prototype.move = function () {
    switch (this.currKey) {
        case 37:
            if (this.pos[0].x <= 0) { this.die(); return; }
            else { this.pos.unshift({ "x": this.pos[0].x - 1, "y": this.pos[0].y }); }
            break;
        case 38:
            if (this.pos[0].y <= 0) { this.die(); return; }
            else { this.pos.unshift({ "x": this.pos[0].x, "y": this.pos[0].y - 1 }); }
            break;
        case 39:
            if (this.pos[0].x >= this.cols - 1) { this.die(); return; }
            else { this.pos.unshift({ "x": this.pos[0].x + 1, "y": this.pos[0].y }); }
            break;
        case 40:
            if (this.pos[0].y >= this.rows - 1) { this.die(); return; }
            else { this.pos.unshift({ "x": this.pos[0].x, "y": this.pos[0].y + 1 }); }
            break;
    };
    if (this.pos[0].x == this.foodPos.x && this.pos[0].y == this.foodPos.y) {
        this.foodPos.x = -1;
        this.food();
    } else if (this.currKey != 0) {
        this.domTab.rows[this.pos[this.pos.length - 1].y].cells[this.pos[this.pos.length - 1].x].className = "";
        this.pos.pop();
    }
    for (i = 3; i < this.pos.length; i++) {
        if (this.pos.x == this.pos[0].x && this.pos.y == this.pos[0].y) {
            this.die();
            return;
        }
    }
    this.domTab.rows[this.pos[0].y].cells[this.pos[0].x].className = "shead";
    this.domTab.rows[this.pos[1].y].cells[this.pos[1].x].className = "sbody";
};
Snake.prototype.die = function () {
    alert("x_x");
    window.clearInterval(this.timer);
    this.init();
}
Snake.prototype.food = function () {
    if (this.foodPos.x == -1) {
        do {
            this.foodPos.y = Math.round(Math.random() * (this.rows - 1));
            this.foodPos.x = Math.round(Math.random() * (this.cols - 1));
        }
        while (this.domTab.rows[this.foodPos.y].cells[this.foodPos.x].className != "")
    }
    this.domTab.rows[this.foodPos.y].cells[this.foodPos.x].className = "sfood";
    document.getElementById("foodNum").innerHTML = this.foodNum++;
};
Snake.prototype.map = function () {
    this.domTab.firstChild ? this.domTab.removeChild(this.domTab.firstChild) : false;
    for (j = 0; j < this.rows; j++) {
        var tr = this.domTab.insertRow(-1);
        for (i = 0; i < this.cols; i++) {
            tr.insertCell(-1);
        }
    }
};
window.onload = function () {
    var orz = new Snake();
    orz.init();
    document.onkeydown = function (e) { orz.trigger(e); };
    document.getElementById("setSpeed").onchange = function () { this.blur(); orz.init(this.value); };
};