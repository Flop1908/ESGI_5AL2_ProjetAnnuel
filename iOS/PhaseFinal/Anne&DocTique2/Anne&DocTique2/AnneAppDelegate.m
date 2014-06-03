//
//  AnneAppDelegate.m
//  Demo2
//
//  Created by Kapi on 23/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneAppDelegate.h"
#import "AnneMenuViewController.h"
#import "AnneViewController.h"

@implementation AnneAppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
    [application setStatusBarStyle:UIStatusBarStyleLightContent];//UIStatusBarStyleBlackOpaque
    
    AnneViewController * viewController = [[AnneViewController alloc] init];
    UINavigationController * controller = [[UINavigationController alloc] initWithRootViewController:viewController];
    viewController.label.text = @"Root view controller";
    viewController.view.backgroundColor = [UIColor greenColor];
    AnneMenuViewController   * menuController = [[AnneMenuViewController alloc] initWithRootViewController:controller
                                                                                           atIndexPath:[NSIndexPath indexPathForRow:0 inSection:0]];
    
    self.window.rootViewController = menuController;
    [self.window makeKeyAndVisible];    
    return YES;
}

@end
