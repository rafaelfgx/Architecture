import { Routes } from "@angular/router";
import { appCanActivate } from "./app.can.activate";
import AppLayoutComponent from "./layouts/layout/layout.component";
import AppLayoutNavComponent from "./layouts/layout-nav/layout-nav.component";

export const routes: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/auth/auth.component") }
        ]
    },
    {
        path: "main",
        component: AppLayoutNavComponent,
        canActivate: [appCanActivate],
        children: [
            { path: "files", loadComponent: () => import("./pages/files/files.component") },
            { path: "form", loadComponent: () => import("./pages/form/form.component") },
            { path: "home", loadComponent: () => import("./pages/home/home.component") },
            { path: "list", loadComponent: () => import("./pages/list/list.component") }
        ]
    },
    {
        path: "**",
        redirectTo: ""
    }
];
