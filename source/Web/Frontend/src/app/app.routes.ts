import { Routes } from "@angular/router";
import { appCanActivate } from "./app.can.activate";
import AppLayoutComponent from "./layouts/layout/layout.component";

export const routes: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            { path: "", pathMatch: "full", loadComponent: () => import("./pages/auth/auth.component") }
        ]
    },
    {
        path: "main",
        loadComponent: () => import("./layouts/layout-nav/layout-nav.component"),
        canActivate: [appCanActivate],
        children: [
            { path: "home", loadComponent: () => import("./pages/home/home.component") }
        ]
    },
    {
        path: "**",
        redirectTo: ""
    }
];
