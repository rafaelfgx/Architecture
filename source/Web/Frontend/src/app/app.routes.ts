import { Routes } from "@angular/router";
import { AppGuard } from "./app.guard";
import { AppLayoutComponent } from "./layouts/layout/layout.component";
import { AppLayoutNavComponent } from "./layouts/layout-nav/layout-nav.component";

export const ROUTES: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/auth/auth.component").then((response) => response.AppAuthComponent) }
        ]
    },
    {
        path: "main",
        component: AppLayoutNavComponent,
        canActivate: [AppGuard],
        children: [
            { path: "files", loadComponent: () => import("./pages/files/files.component").then((response) => response.AppFilesComponent) },
            { path: "form", loadComponent: () => import("./pages/form/form.component").then((response) => response.AppFormComponent) },
            { path: "home", loadComponent: () => import("./pages/home/home.component").then((response) => response.AppHomeComponent) },
            { path: "list", loadComponent: () => import("./pages/list/list.component").then((response) => response.AppListComponent) }
        ]
    },
    {
        path: "**",
        redirectTo: ""
    }
];
