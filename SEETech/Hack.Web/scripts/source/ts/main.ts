﻿/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="router.ts" />
/// <reference path="search.ts" />
/// <reference path="../../typing/sammy/sammyjs.d.ts" />
var Bootcards: any;
var app: Sammy.Application = Sammy();
(<any>app).element_selector = "#container";
var router: Hack.Router = new Hack.Router("http://hackapi.azurewebsites.net/api/");

var partials: { [key: string]: string; } = {};

var viewmodel: any = {};

partials["detail"] = "/views/detail.html";
partials["about"] = "/views/about.html";
partials["info"] = "/views/info.html";
partials["list"] = "/views/list.html";
partials["map"] = "/views/map.html";
partials["search"] = "/views/search.html";
partials["start"] = "/views/start.html";

app.get("/#/", (context: Sammy.EventContext) => {
    $("#navigation").css("display", "none");
    context.partial(partials["start"], (context: Sammy.EventContext) => {
    });
});

app.get('/#/about/', (context: Sammy.EventContext) => {
    $("#navigation").css("display", "block");
    console.log("about", context.params);
    setActive("about");
    Bootcards.OffCanvas.hide();
    context.partial(partials["about"], (context: Sammy.EventContext) => {
    });
});
app.get('/#/info/', (context: Sammy.EventContext) => {
    $("#navigation").css("display", "block");
    setActive("info");
    console.log("info", context.params);
    Bootcards.OffCanvas.hide();
    context.partial(partials["info"], (context: Sammy.RenderContext) => {
    });
});


app.get('/#/map/', (context: Sammy.EventContext) => {
    $("#navigation").css("display", "block");
    setActive("map");
    console.log("map", context.params);
    Bootcards.OffCanvas.hide();
    context.partial(partials["map"], (render: Sammy.RenderContext) => {
    });
});

app.get('/#/search/', (context: Sammy.EventContext) => {
    $("#navigation").css("display", "block");
    setActive("search");
    console.log("search", context.params);
    Bootcards.OffCanvas.hide();
    context.partial(partials["search"], (render: Sammy.RenderContext) => {
        if (ko.dataFor($("#search")[0]) != null) ko.cleanNode($("#search")[0]);
        router.getProvinces((provinces: Array<Hack.Province>) => {
            viewmodel = new Hack.SearchViewModel(provinces);
        });

        ko.applyBindings(viewmodel, $("#search")[0]);
    });
});
app.get('/#/list/:json/', (context: Sammy.EventContext) => {
    $("#navigation").css("display", "block");
    setActive("search");
    console.log("list", context.params);
    Bootcards.OffCanvas.hide();
    var json = context.params.json;
    context.partial(partials["list"], (render: Sammy.RenderContext) => {
        if (ko.dataFor($("#list")[0]) != null) ko.cleanNode($("#list")[0]);
        router.getList(json, (searchResult) => {
            console.log(searchResult);
            viewmodel = ko.mapping.fromJS(searchResult);
            ko.applyBindings(viewmodel, $("#list")[0]);
        });
    });
});
app.get('/#/detail/:id/', (context: Sammy.EventContext) => {
    $("#navigation").css("display", "block");
    console.log("detail", context.params);
    Bootcards.OffCanvas.hide();
    context.partial(partials["detail"], (render: Sammy.RenderContext) => {
    });
});




app.run('/#/');

function setActive(id: string) {
    $("#mapSide").removeClass("active");
    $("#searchSide").removeClass("active");
    $("#infoSide").removeClass("active");
    $("#aboutSide").removeClass("active");
    console.log("#" + id + "Side");
    $("#" + id + "Side").addClass("active");
}