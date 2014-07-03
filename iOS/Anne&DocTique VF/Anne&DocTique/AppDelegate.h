//
//  AppDelegate.h
//  Anne&DocTique
//
//  Created by Kapi on 29/01/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>

@interface AppDelegate : UIResponder <UIApplicationDelegate>
//Declaration in the Delegate for the app
@property (strong, nonatomic) UIWindow *window;
//For the Version 2
@property (strong, nonatomic) CLLocationManager *locationManager;

@end
