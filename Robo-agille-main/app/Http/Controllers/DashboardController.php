<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class DashboardController extends Controller
{
    // Dashboard - Analytics
    public function dashboardAnalytics()
    {
        $pageConfigs = ['pageHeader' => false, 'slug' => 'home'];

        return view('/content/dashboard/dashboard-analytics', ['pageConfigs' => $pageConfigs]);
    }

    public function home()
    {
        $pageConfigs = ['pageHeader' => false, 'slug' => 'home'];

        return view('/content/dashboard/dashboard-ecommerce', ['pageConfigs' => $pageConfigs]);
    }

    // Dashboard - Ecommerce
    public function dashboardEcommerce()
    {
        $pageConfigs = ['pageHeader' => false, 'slug' => 'home'];

        return view('/content/dashboard/dashboard-ecommerce', ['pageConfigs' => $pageConfigs]);
    }

    public function dashboardHome()
    {
        $pageConfigs = ['pageHeader' => false, 'slug' => 'dashboard-home'];

        return view('/content/dashboard/dashboard-ecommerce', ['pageConfigs' => $pageConfigs]);
    }
}
