//
//  PostsTableControllerView.h
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PostCell.h"
#import "RedditAPI.h"
//Pas sur
#import "JSON.h"

@interface PostsTableControllerView : UITableViewController <UIPickerViewDelegate> {
	NSMutableArray * posts;
	NSMutableArray * subreddits;
	NSString * subreddit;
	NSTimer * progressTimer;
	NSTimer * timer;
	IBOutlet UISegmentedControl *segmentControl;
	UISegmentedControl * scrollSegmentControl;	
	IBOutlet UIView * subredditPickView;	
	IBOutlet UIView * subredditManualEnterView;	
	IBOutlet UIPickerView * subredditScrollingPickerView;
	IBOutlet  UITextField * subredditManualText;
	IBOutlet UIButton * subredditDoneButton;
	UIBarButtonItem * introButton;
	UIBarButtonItem * fullscreenButton;
	RedditAPI * redAPI;
	float ProgressValue;
	NSUserDefaults * prefs;	
	BOOL resultsFetched;

//	// we use this when switching to/from fullscreen mode
//	CGRect oldTableViewFrame;

	// We maintain two hide queues, one that the API calls to Reddit, and this one.
	// The reason for this localHideQueue is that a "hide" call may not be finished
	// before a fetchPosts call is made.  This would result in one or two posts
	// being shown even though the user wanted to hide them.
	NSMutableArray * localHideQueue;
}

@property (readwrite, copy) NSString * subreddit;
@property (nonatomic, retain) IBOutlet  UISegmentedControl *segmentControl;
@property (nonatomic, retain) IBOutlet  UIView *subredditPickView;
@property (nonatomic, retain) IBOutlet  UIPickerView *subredditScrollingPickerView;
@property (nonatomic, retain) IBOutlet  UIView *subredditManualEnterView;
@property (nonatomic, retain) IBOutlet  UITextField *subredditManualText;
@property (nonatomic, retain) IBOutlet  UIButton *subredditDoneButton;

- (IBAction) fetchPosts:(id)sender;
- (IBAction)loadPosts:(id)sender;
- (IBAction)chooseSubredditButton:(id)sender;
- (IBAction)cancelSubredditSelect:(id)sender;
- (void) hideSinglePost:(NSMutableDictionary *) post;
- (void) showCommentsForPost:(NSMutableDictionary *) post;
- (void) openLinkForPost:(NSMutableDictionary *) post;
- (void) clearAndRefreshFromSettingsLogin;
- (void) refreshSegmentControl;
- (void) removeSegmentControl;
@end

