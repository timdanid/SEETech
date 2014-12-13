﻿/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/knockout/knockout.d.ts" />
/// <reference path="../../typing/knockout.mapping/knockout.mapping.d.ts" />


module Hack {

    export class City {

        public id: string;
        public name: string;

        constructor(id: string, name: string) {
            this.id = id;
            this.name = name;
        }
    }

    export class Province {

        public id: string;
        public name: string;

        constructor(id: string, name: string) {
            this.id = id;
            this.name = name;
        }

    }

    export class SearchViewModel {

        public cities: KnockoutObservableArray<City>;
        public provinces: KnockoutObservableArray<Province>;
        public selectedCity: KnockoutObservable<City>;
        public selectedProvince: KnockoutObservable<Province>;

        public general: KnockoutObservable<boolean>;
        public dental: KnockoutObservable<boolean>;
        public woman: KnockoutObservable<boolean>;
        public preschool: KnockoutObservable<boolean>;

        constructor(provinces: Array<Province>) {
            this.provinces = ko.observableArray(provinces);
            this.selectedProvince = ko.observable(null);
            this.selectedCity = ko.observable(null);

            this.cities = ko.observableArray([]);

            this.general = ko.observable(true);
            this.dental = ko.observable(true);
            this.woman = ko.observable(true);
            this.preschool = ko.observable(true);
        }
    }
}