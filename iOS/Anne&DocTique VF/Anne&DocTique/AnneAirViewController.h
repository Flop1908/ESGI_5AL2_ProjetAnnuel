//
//  AnneAirViewController.h
//  Anne&DocTique
//
//  Created by Kapi on 23/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "AnneSessionView.h"

@protocol AnneAirMenuDelegate <NSObject>
@optional
- (BOOL)shouldSelectRowAtIndex:(NSIndexPath*)indexPath;
- (void)didSelectRowAtIndex:(NSIndexPath*)indexPath;

- (void)willShowAirViewController;
- (void)willHideAirViewController;
- (void)didHideAirViewController;

- (float)heightForAirMenuRow;
- (NSIndexPath*)indexPathDefaultValue;

@end

@protocol AnneAirMenuDataSource <NSObject>
@required
- (NSInteger)numberOfSession;
- (NSInteger)numberOfRowsInSession:(NSInteger)sesion;
- (NSString*)titleForRowAtIndexPath:(NSIndexPath*)indexPath;
- (NSString*)titleForHeaderAtSession:(NSInteger)session;
@optional
- (UIImage*)thumbnailImageAtIndexPath:(NSIndexPath*)indexPath;
- (NSString*)segueForRowAtIndexPath:(NSIndexPath*)indexPath;
- (UIViewController*)viewControllerForIndexPath:(NSIndexPath*)indexPath;
@end

@interface AnneAirViewController : UIViewController <AnneAirMenuDelegate, AnneAirMenuDataSource, UIGestureRecognizerDelegate>

@property (nonatomic, strong) UIColor * titleNormalColor;
@property (nonatomic, strong) UIColor * titleHighlightColor;

@property (nonatomic, assign) id <AnneAirMenuDelegate>   delegate;
@property (nonatomic, assign) id <AnneAirMenuDataSource> dataSource;

@property (nonatomic, readonly) UIViewController * fontViewController;
@property (nonatomic, strong)   NSIndexPath      * currentIndexPath;

- (id)initWithRootViewController:(UIViewController*)viewController atIndexPath:(NSIndexPath*)indexPath;

- (void)reloadData;
- (void)showAirViewFromViewController:(UIViewController*)controller complete:(void (^)(void))complete;
- (void)switchToViewController:(UIViewController*)controller atIndexPath:(NSIndexPath*)indexPath;
- (void)switchToViewController:(UIViewController*)controller;

@end

#pragma mark - AnneAirViewControllerDelegate Protocol

@protocol AnneAirViewControllerDelegate<NSObject>
@optional
@end

#pragma mark - UIViewController(AnneAirViewController) Category

// We add a category of UIViewController to let childViewControllers easily access their parent AnneAirViewController
@interface UIViewController(AnneAirViewController)

@property (nonatomic, readonly) UISwipeGestureRecognizer * AnneSwipeGestureRecognizer;
@property (nonatomic, copy)     void (^AnneSwipeHander)(void);

- (AnneAirViewController*)airViewController;

@end


// This will allow the class to be defined on a storyboard
#pragma mark - AnneAirViewControllerSegue

@interface AnneAirViewControllerSegue : UIStoryboardSegue
@property (strong) void(^performBlock)( AnneAirViewControllerSegue * segue, UIViewController * svc, UIViewController * dvc );
@end