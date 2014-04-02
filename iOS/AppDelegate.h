//
//  AppDelegate.h
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "RedditAPI.h"
#import "NavigationController.h"

@interface AppDelegate : NSObject <UIApplicationDelegate, UITabBarControllerDelegate> {
    UIWindow *window;
    IBOutlet NavigationController *tabBarController;
	RedditAPI * redditAPI;
	NSTimer * inboxCheckTimer;
	NSUserDefaults * prefs;
	UIImageView * errorImage;
	IBOutlet UIImageView * blackBG;
}

@property (readonly, strong, nonatomic) NSManagedObjectContext *managedObjectContext;
@property (readonly, strong, nonatomic) NSManagedObjectModel *managedObjectModel;
@property (readonly, strong, nonatomic) NSPersistentStoreCoordinator *persistentStoreCoordinator;
@property (nonatomic, retain) IBOutlet UIWindow *window;
@property (nonatomic, retain) IBOutlet NavigationController *tabBarController;
@property (nonatomic, retain) IBOutlet UIImageView *blackBG;
@property (readwrite, retain) RedditAPI *redditAPI;
- (void) refreshUnreadMailBadge;
-(IBAction) checkForNewMessages: (id) sender;
- (void) proVersionUpgraded;

- (void) showConnectionErrorImage;
- (void) hideConnectionErrorImage;
- (void) refreshBackground;
- (void) stopPurchaseIndicator;
- (void)saveContext;
@end

