//
//  SettingsViewController.h
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "RedditAPI.h"

@interface SettingsTableViewController : UITableViewController <UITextFieldDelegate> {
	UITextField *usernameField; //Login
	UITextField *passwordField; //Password
	UITextField *newFilterField; //NewFilter
	IBOutlet UILabel *modLabel;
	IBOutlet UILabel *cookieLabel;	
	NSUserDefaults * prefs;
	UIActivityIndicatorView * purchaseActivity;
//	UIScrollView * proSplashView;
	UIScrollView * tipsView;
	UIView * settingsView;	
	RedditAPI * redAPI;
}

@property (nonatomic, retain) IBOutlet  UILabel *modLabel;	
@property (nonatomic, retain) IBOutlet  UILabel *cookieLabel;	

- (IBAction)authorise:(id)sender;
- (void) showTipsSplash;
- (void) stopPurchaseActivityIndicator;
- (void) showProSplash;
@end
