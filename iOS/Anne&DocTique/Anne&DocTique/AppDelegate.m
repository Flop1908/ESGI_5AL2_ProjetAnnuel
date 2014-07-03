//
//  AppDelegate.m
//  Anne&DocTique
//
//  Created by Kapi on 29/01/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AppDelegate.h"

#import "AnneMenuViewController.h"
#import "MasterViewController.h"

@interface AppDelegate ()<CLLocationManagerDelegate>

@end

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    //Location Manager's allocation
    self.locationManager = [[CLLocationManager alloc] init];
    //If we autorized the device's location
    if ([CLLocationManager locationServicesEnabled]) {
        //To Update the Location
        [self.locationManager setDelegate:self];
        [self.locationManager startUpdatingLocation];
    }
    UINavigationController *navigationController = (UINavigationController *)self.window.rootViewController;
    MasterViewController *controller = (MasterViewController *)navigationController.topViewController;
    UINavigationController * NaviController = [[UINavigationController alloc] initWithRootViewController:controller];
    AnneMenuViewController   * menuController = [[AnneMenuViewController alloc] initWithRootViewController:NaviController
                                                                                               atIndexPath:[NSIndexPath indexPathForRow:0 inSection:0]];
    self.window.rootViewController = menuController;
    //[self.window makeKeyAndVisible];
    return YES;
}

#pragma mark - CLLocationManagerDelegate
//Autorization's fonction
- (void)locationManager:(CLLocationManager *)manager didChangeAuthorizationStatus:(CLAuthorizationStatus)status
{
    if (status == kCLAuthorizationStatusAuthorized) {
        [[NSNotificationCenter defaultCenter] postNotificationName:@"kCLAuthorizationStatusAuthorized" object:self];
    }
}

@end
