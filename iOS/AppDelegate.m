//
//  AppDelegate.m
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

/*
- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    // Override point for customization after application launch.
    UINavigationController *navigationController = (UINavigationController *)self.window.rootViewController;
    MasterViewController *controller = (MasterViewController *)navigationController.topViewController;
    controller.managedObjectContext = self.managedObjectContext;
    return YES;
}
							
- (void)applicationWillResignActive:(UIApplication *)application
{
    // Sent when the application is about to move from active to inactive state. This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) or when the user quits the application and it begins the transition to the background state.
    // Use this method to pause ongoing tasks, disable timers, and throttle down OpenGL ES frame rates. Games should use this method to pause the game.
}

- (void)applicationDidEnterBackground:(UIApplication *)application
{
    // Use this method to release shared resources, save user data, invalidate timers, and store enough application state information to restore your application to its current state in case it is terminated later. 
    // If your application supports background execution, this method is called instead of applicationWillTerminate: when the user quits.
}

- (void)applicationWillEnterForeground:(UIApplication *)application
{
    // Called as part of the transition from the background to the inactive state; here you can undo many of the changes made on entering the background.
}

- (void)applicationDidBecomeActive:(UIApplication *)application
{
    // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
}

- (void)applicationWillTerminate:(UIApplication *)application
{
    // Saves changes in the application's managed object context before the application terminates.
    [self saveContext];
}



// Returns the managed object context for the application.
// If the context doesn't already exist, it is created and bound to the persistent store coordinator for the application.
- (NSManagedObjectContext *)managedObjectContext
{
    if (_managedObjectContext != nil) {
        return _managedObjectContext;
    }
    
    NSPersistentStoreCoordinator *coordinator = [self persistentStoreCoordinator];
    if (coordinator != nil) {
        _managedObjectContext = [[NSManagedObjectContext alloc] init];
        [_managedObjectContext setPersistentStoreCoordinator:coordinator];
    }
    return _managedObjectContext;
}

// Returns the managed object model for the application.
// If the model doesn't already exist, it is created from the application's model.
- (NSManagedObjectModel *)managedObjectModel
{
    if (_managedObjectModel != nil) {
        return _managedObjectModel;
    }
    NSURL *modelURL = [[NSBundle mainBundle] URLForResource:@"A_D" withExtension:@"momd"];
    _managedObjectModel = [[NSManagedObjectModel alloc] initWithContentsOfURL:modelURL];
    return _managedObjectModel;
}

// Returns the persistent store coordinator for the application.
// If the coordinator doesn't already exist, it is created and the application's store added to it.
- (NSPersistentStoreCoordinator *)persistentStoreCoordinator
{
    if (_persistentStoreCoordinator != nil) {
        return _persistentStoreCoordinator;
    }
    
    NSURL *storeURL = [[self applicationDocumentsDirectory] URLByAppendingPathComponent:@"A_D.sqlite"];
    
    NSError *error = nil;
    _persistentStoreCoordinator = [[NSPersistentStoreCoordinator alloc] initWithManagedObjectModel:[self managedObjectModel]];
    if (![_persistentStoreCoordinator addPersistentStoreWithType:NSSQLiteStoreType configuration:nil URL:storeURL options:nil error:&error]) {
        /*
         Replace this implementation with code to handle the error appropriately.
         
         abort() causes the application to generate a crash log and terminate. You should not use this function in a shipping application, although it may be useful during development. 
         
         Typical reasons for an error here include:
         * The persistent store is not accessible;
         * The schema for the persistent store is incompatible with current managed object model.
         Check the error message to determine what the actual problem was.
         
         
         If the persistent store is not accessible, there is typically something wrong with the file path. Often, a file URL is pointing into the application's resources directory instead of a writeable directory.
         
         If you encounter schema incompatibility errors during development, you can reduce their frequency by:
         * Simply deleting the existing store:
         [[NSFileManager defaultManager] removeItemAtURL:storeURL error:nil]
         
         * Performing automatic lightweight migration by passing the following dictionary as the options parameter:
         @{NSMigratePersistentStoresAutomaticallyOption:@YES, NSInferMappingModelAutomaticallyOption:@YES}
         
         Lightweight migration will only work for a limited set of schema changes; consult "Core Data Model Versioning and Data Migration Programming Guide" for details.
         
 
        NSLog(@"Unresolved error %@, %@", error, [error userInfo]);
        abort();
    }    
    
    return _persistentStoreCoordinator;
}

*/

#import "AppDelegate.h"
#import "MessagesTableViewController.h"
#import "SettingsTableViewController.h"

@implementation AppDelegate

@synthesize managedObjectContext = _managedObjectContext;
@synthesize managedObjectModel = _managedObjectModel;
@synthesize persistentStoreCoordinator = _persistentStoreCoordinator;
@synthesize window;
@synthesize tabBarController;
@synthesize redditAPI;
@synthesize blackBG;

- (void) authtest1:(id) sender
{
	NSLog(@"authtest1 in()");
	if ([redditAPI authenticated])
	{
		NSLog(@"-- user is authenticated --");
		[self refreshUnreadMailBadge];
	}
	else
		NSLog(@"-- not logged in --");
}

-(IBAction) checkForNewMessages: (id) sender
{
	if ([redditAPI authenticated])
		[redditAPI fetchUnreadMessageCount:self];
}

-(IBAction) apiUnreadMessageCountResponse: (id) sender
{
	NSLog(@"-- new results for unread message count : %d", [redditAPI unreadMessageCount]);
	[self refreshUnreadMailBadge];
}

- (void) refreshUnreadMailBadge
{
	UITabBarItem *  messagesTab = [[[tabBarController tabBar] items] objectAtIndex:1];
	if([redditAPI unreadMessageCount] > 0)
	{
		[messagesTab setBadgeValue:[NSString stringWithFormat:@"%d",[redditAPI unreadMessageCount]]];
	}
	else
	{
		[messagesTab setBadgeValue:nil];
	}
}


// this is to handle users clicking "Upgrade Now" in UIAlert dialogs
- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex
{
	if(alertView.tag == 99 && buttonIndex == 1)
	{
		NSLog(@"Upgrade Now Pressed");
		[tabBarController setSelectedIndex:2];
        
		NSIndexPath * ind = [NSIndexPath indexPathForRow:0 inSection:7];
		[[(SettingsTableViewController *) [tabBarController selectedViewController] tableView] scrollToRowAtIndexPath:ind atScrollPosition:UITableViewScrollPositionTop animated:NO];
	}
}

- (void) refreshBackground
{
	if ([prefs boolForKey:@"night_mode"])
		[blackBG setHidden:NO];
	else
		[blackBG setHidden:YES];
}

- (void) stopPurchaseIndicator
{
	if ([tabBarController selectedIndex] == 2)
	{
		[(SettingsTableViewController *) [tabBarController selectedViewController] stopPurchaseActivityIndicator];
	}
}

- (void) proVersionUpgraded
{
	NSLog(@"proVersionUpgraded");
    
	if ([tabBarController selectedIndex] == 2)
	{
		// refresh settings - so that the "Thank you message" now displays
		[[(SettingsTableViewController *) [tabBarController selectedViewController] tableView] reloadData];
		[(SettingsTableViewController *) [tabBarController selectedViewController] stopPurchaseActivityIndicator];
	}
}

- (void) showConnectionErrorImage
{
	if (![errorImage superview])
		[window insertSubview:errorImage atIndex:99];
}

- (void) hideConnectionErrorImage
{
	if ([errorImage superview])
		[errorImage removeFromSuperview];
}

- (void)applicationDidFinishLaunching:(UIApplication *)application {
    
	errorImage = [[UIImageView alloc] initWithImage:[[UIImage imageNamed:@"no-internet-connection.png"] retain]];
    
	prefs = [NSUserDefaults standardUserDefaults];
	
	// setup the default user settings on first launch
	if(![prefs boolForKey:@"already_ran"] )
	{
		[prefs setBool:YES forKey:@"already_ran"];
        
		[prefs setBool:YES forKey:@"use_lowres_imgur"];
		[prefs setBool:YES forKey:@"use_direct_imgur_link"];
        
		[prefs setBool:YES forKey:@"show_hide_queue"];
		[prefs setBool:YES forKey:@"show_thumbs"];
		[prefs setBool:YES forKey:@"show_help_icon"];
		[prefs setBool:NO forKey:@"night_mode"];
		[prefs setBool:NO forKey:@"auto_mark_as_read"];
		[prefs setBool:YES forKey:@"allow_rotation"];
		[prefs setBool:YES forKey:@"allow_status_bar_scroll"];
		[prefs setBool:NO forKey:@"show_quick_scroll"];
		[prefs setBool:NO forKey:@"allow_tilt_scroll"];
		[prefs setInteger:1 forKey:@"textsize"];
		[prefs setInteger:0 forKey:@"fetch_message_frequency"];
		[prefs synchronize];
	}
    
	if(![prefs objectForKey:@"filterList"])
	{
		NSLog(@"initialising post filter");
		NSMutableArray * filterList = [NSMutableArray arrayWithCapacity:1];
		[prefs setObject:filterList forKey:@"filterList"];
		[prefs synchronize];
	}
	else
	{
		NSMutableArray * filterList = (NSMutableArray *) [prefs objectForKey:@"filterList"];
		for (NSString * filterItem in filterList)
		{
			NSLog(@"Filter Item : %@", filterItem);
		}
	}
	
	
	// Always disable tilt-scroll on launch.  Otherwise, the user is going to get
	// unexpected scrolling if they forgot that tilt-scroll was activated previously.
   	[prefs setBool:NO forKey:@"allow_tilt_scroll"];
	[prefs synchronize];
	
	[MKStoreManager sharedManager];
    
	if([MKStoreManager isProUpgraded])
	{
		NSLog(@"-- pro version in use --");
	}
	else
	{
		NSLog(@"-- free version in use --");
	}
	
    // Add the tab bar controller's current view as a subview of the window
    [window addSubview:tabBarController.view];
	[tabBarController setDelegate:tabBarController];
    
	redditAPI = [[RedditAPI alloc] init];
	[tabBarController loadNibs];
    
	[redditAPI testReachability];
	
	[redditAPI authenticateWithCallbackTarget:self andCallBackAction:@"authtest1:"];
	int freq_selection = [[prefs valueForKey:@"fetch_message_frequency"] intValue];
	int checkTime = -1;
	if (freq_selection == 1)
		checkTime = 2 * 60;
	else if (freq_selection == 2)
		checkTime = 5 * 60;
	else if (freq_selection == 3)
		checkTime = 10 * 60;
    
    
	if (checkTime > 0)
	{
		NSLog(@"-- will check for messages every %d minutes", checkTime / 60);
		inboxCheckTimer = [NSTimer scheduledTimerWithTimeInterval:checkTime
														   target:self
														 selector:@selector(checkForNewMessages:)
														 userInfo:nil
														  repeats:YES];
	}
	else
		NSLog(@"-- manual message checking --");
	
	[self refreshBackground];
	
    //	[self showConnectionErrorImage];
}

- (void)saveContext
{
    NSError *error = nil;
    NSManagedObjectContext *managedObjectContext = self.managedObjectContext;
    if (managedObjectContext != nil) {
        if ([managedObjectContext hasChanges] && ![managedObjectContext save:&error]) {
            // Replace this implementation with code to handle the error appropriately.
            // abort() causes the application to generate a crash log and terminate. You should not use this function in a shipping application, although it may be useful during development.
            NSLog(@"Unresolved error %@, %@", error, [error userInfo]);
            abort();
        }
    }
}

#pragma mark - Core Data stack
/*
 // Optional UITabBarControllerDelegate method
 - (void)tabBarController:(UITabBarController *)tabBarController didSelectViewController:(UIViewController *)viewController {
 }
 */

/*
 // Optional UITabBarControllerDelegate method
 - (void)tabBarController:(UITabBarController *)tabBarController didEndCustomizingViewControllers:(NSArray *)viewControllers changed:(BOOL)changed {
 }
 */


- (void)dealloc {
    [tabBarController release];
    [window release];
    [super dealloc];
}




@end
