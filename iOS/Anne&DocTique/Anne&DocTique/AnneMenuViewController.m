//
//  AnneMenuViewController.m
//  Anne&DocTique
//
//  Created by Kapi on 15/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneMenuViewController.h"

@implementation AnneMenuViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor whiteColor];
}

#pragma mark - AnneAirMenuDelegate & DataSource

- (NSInteger)numberOfSession
{
    return 2;
}

- (NSInteger)numberOfRowsInSession:(NSInteger)sesion
{
    return 3;
}

- (NSString*)titleForRowAtIndexPath:(NSIndexPath*)indexPath
{
    return [NSString stringWithFormat:@"pika %ld in %ld", (long)indexPath.row, (long)indexPath.section];
}

- (NSString*)titleForHeaderAtSession:(NSInteger)session
{
    return [NSString stringWithFormat:@"Session %ld", (long)session];
}

- (UIViewController*)viewControllerForIndexPath:(NSIndexPath*)indexPath
{
    AnneViewController * viewController = [[AnneViewController alloc] init];
    UINavigationController * controller = [[UINavigationController alloc] initWithRootViewController:viewController];
    viewController.label.text = [NSString stringWithFormat:@"View controller %d in session %d", indexPath.row, indexPath.section];
    switch (indexPath.row) { //doc: sources de donn
        case 0://VDM
            viewController.view.backgroundColor = [UIColor greenColor];//mettre Url de donnée du Json de VDM
            break;
        case 1:
            viewController.view.backgroundColor = [UIColor yellowColor];
            break;
        case 2:
            viewController.view.backgroundColor = [UIColor redColor];
            break;
    }
    return controller;
}

@end
