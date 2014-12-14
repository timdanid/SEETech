/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/knockout/knockout.d.ts" />
/// <reference path="../../typing/knockout.mapping/knockout.mapping.d.ts" />


module Hack {

    export class Marker {
        public name: string;
        public location: string;
        public id: string;

        public x_coordinate: Int32Array;
        public y_coordinate: Int32Array;

        public title: string;
        public icon: string;

        constructor(Name: string, Location: string, X: Int32Array, Y: Int32Array, Title: string, Icon: string, Id: string) {
            this.name = Name;
            this.location = Location;
            this.x_coordinate = X;
            this.y_coordinate = Y;
            this.title = Title;
            this.icon = Icon;
            this.id = Id;
        }

    }
}