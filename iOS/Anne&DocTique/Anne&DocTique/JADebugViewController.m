//
//  JADebugViewController.m
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//


#import "JADebugViewController.h"

@interface JADebugViewController ()

@end

@implementation JADebugViewController

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    NSLog(@"%@ viewWillAppear", self);
}

- (void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
    NSLog(@"%@ viewDidAppear", self);
}

- (void)viewWillDisappear:(BOOL)animated {
    [super viewWillDisappear:animated];
    NSLog(@"%@ viewWillDisappear", self);
}

- (void)viewDidDisappear:(BOOL)animated {
    [super viewDidDisappear:animated];
    NSLog(@"%@ viewDidDisappear", self);
}

- (void)willMoveToParentViewController:(UIViewController *)parent {
    [super willMoveToParentViewController:parent];
    NSLog(@"%@ willMoveToParentViewController %@", self, parent);
}

- (void)didMoveToParentViewController:(UIViewController *)parent {
    [super didMoveToParentViewController:parent];
    NSLog(@"%@ didMoveToParentViewController %@", self, parent);
}

@end
