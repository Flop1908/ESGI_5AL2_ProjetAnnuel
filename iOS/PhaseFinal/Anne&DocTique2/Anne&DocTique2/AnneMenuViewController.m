//
//  AnneMenuViewController.m
//  Demo2
//
//  Created by Kapi on 23/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneMenuViewController.h"
#import "AnneViewController.h"

@implementation AnneMenuViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor cyanColor];
}

#pragma mark - AnneAirMenuDelegate & DataSource
//Numbre of Session
- (NSInteger)numberOfSession
{
    return 2;
}
//Number Of Title In AirMenu
- (NSInteger)numberOfRowsInSession:(NSInteger)sesion
{
    return 5;
}
//String for Title
- (NSString*)titleForRowAtIndexPath:(NSIndexPath*)indexPath
{
    switch (indexPath.row) {
        case 0:
            return [NSString stringWithFormat:@"Accueil"];;
            break;
            
        case 1:
            return [NSString stringWithFormat:@"VDM"];
            break;
            
        case 2:
            return [NSString stringWithFormat:@"DTC"];
            break;
            
        case 3:
            return [NSString stringWithFormat:@"CNF"];
            break;
            
        case 4:
            return [NSString stringWithFormat:@"Setting"];
            break;
            
        default:
            return [NSString stringWithFormat:@"Erreur de source"];
            break;
    }
    //return [NSString stringWithFormat:@"Row %ld", (long)indexPath.row];// (long)indexPath.section
}
//Title of HeaderView
- (NSString*)titleForHeaderAtSession:(NSInteger)session
{
    return [NSString stringWithFormat:@"Source d'Anne&DocTique"];
}
//viewController for Each Title
- (UIViewController*)viewControllerForIndexPath:(NSIndexPath*)indexPath
{
    AnneViewController * viewController = [[AnneViewController alloc] init];
    UINavigationController * controller = [[UINavigationController alloc] initWithRootViewController:viewController];
    viewController.label.text = [NSString stringWithFormat:@"la source est %d ", indexPath.row];
    switch (indexPath.row) {
        case 0:
            viewController.view.backgroundColor =[UIColor whiteColor];//Acceuil avec toutes les Annecdotes
            break;
        case 1:
            viewController.view.backgroundColor = [UIColor blueColor];//VDM
            break;
        case 2:
            viewController.view.backgroundColor = [UIColor greenColor];//DTC
            break;
        case 3:
            viewController.view.backgroundColor = [UIColor brownColor];//CNF
            break;
        case 4:
            viewController.view.backgroundColor =[UIColor purpleColor];//Setting
    }
    return controller;
}

@end
