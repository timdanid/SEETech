/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="router.ts" />
/// <reference path="search.ts" />
/// <reference path="../../typing/sammy/sammyjs.d.ts" />
var Bootcards;
var app = Sammy();
app.element_selector = "#container";
var router = new Hack.Router("http://hackapi.azurewebsites.net/api/");

var partials = {};

var viewmodel = {};

partials["detail"] = "/views/detail.html";
partials["about"] = "/views/about.html";
partials["info"] = "/views/info.html";
partials["list"] = "/views/list.html";
partials["map"] = "/views/map.html";
partials["search"] = "/views/search.html";
partials["start"] = "/views/start.html";

app.get("/#/", function (context) {
    $("#navigation").css("display", "none");
    context.partial(partials["start"], function (context) {
    });
});

app.get('/#/about/', function (context) {
    $("#navigation").css("display", "block");
    setActive("about");
    Bootcards.OffCanvas.hide();
    context.partial(partials["about"], function (context) {
    });
});
app.get('/#/info/', function (context) {
    $("#navigation").css("display", "block");
    setActive("info");
    Bootcards.OffCanvas.hide();
    context.partial(partials["info"], function (context) {
    });
});

app.get('/#/map/', function (context) {
    $("#navigation").css("display", "block");
    setActive("map");
    Bootcards.OffCanvas.hide();
    context.partial(partials["map"], function (render) {
    });
});

app.get('/#/search/', function (context) {
    $("#navigation").css("display", "block");
    setActive("search");
    Bootcards.OffCanvas.hide();
    context.partial(partials["search"], function (render) {
        if (ko.dataFor($("#search")[0]) != null)
            ko.cleanNode($("#search")[0]);
        router.getProvinces(function (provinces) {
            viewmodel = new Hack.SearchViewModel(provinces);
            ko.applyBindings(viewmodel, $("#search")[0]);
        });
    });
});
app.get('/#/list/:json/', function (context) {
    $("#navigation").css("display", "block");
    setActive("search");
    Bootcards.OffCanvas.hide();
    var json = JSON.parse(context.params.json);
    context.partial(partials["list"], function (render) {
        if (ko.dataFor($("#list")[0]) != null)
            ko.cleanNode($("#list")[0]);
        router.getList(json.city.name, json.general, json.preschool, json.woman, json.dental, function (searchResult) {
            viewmodel = ko.mapping.fromJS(searchResult);
            ko.applyBindings(viewmodel, $("#list")[0]);
        });
    });
});
app.get('/#/detail/:id/', function (context) {
    $("#navigation").css("display", "block");
    console.log("detail", context.params);
    Bootcards.OffCanvas.hide();
    var id = context.params.id;
    context.partial(partials["detail"], function (render) {
        router.getDetail(id, function (data) {
            console.log(data);
        });
    });
});

app.run('/#/');

function setActive(id) {
    $("#mapSide").removeClass("active");
    $("#searchSide").removeClass("active");
    $("#infoSide").removeClass("active");
    $("#aboutSide").removeClass("active");
    console.log("#" + id + "Side");
    $("#" + id + "Side").addClass("active");
}
//# sourceMappingURL=main.js.map
